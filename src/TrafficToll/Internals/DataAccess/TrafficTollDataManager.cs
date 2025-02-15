using System.Text.Json;
using System.Reflection;
using TrafficToll.Internals.Exceptions;
using TrafficToll.Internals.DataAccess.Models;
using TrafficToll.Internals.Enums;
using TrafficToll.Internals.ValueObjects;

namespace TrafficToll.Internals.DataAccess;

internal static class TrafficTollDataManager
{
    private static TrafficTollSpecification? __trafficTollSpecification;
    private static TrafficTollSpecification TrafficTollSpecification => __trafficTollSpecification ??= GetTollSpecificationFromAssemblyEmbeddedJsonFile();
    
    public static TollCalculationParameters GetTollCalculationParameters()
    {
        return CreateTollCalculationParameters();
    }

    public static TollableParameters GetTollFreeParameters()
    {
        var tollFreeDateTuples = TrafficTollSpecification.TollFreeDates.Select(x => (x.Year, x.Month, x.Day));

        return new TollableParameters(
            TrafficTollSpecification.TollFreeVehicleTypes.Select(x => (VehicleType)x),
            tollFreeDateTuples);
    }

    private static TrafficTollSpecification GetTollSpecificationFromAssemblyEmbeddedJsonFile()
    {
        var jsonDbName = "traffic_toll_2013.json";
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = $"{nameof(TrafficToll)}.{nameof(Internals)}.{nameof(DataAccess)}.FileDb.{jsonDbName}";

        Stream? stream = null;
        StreamReader? reader = null;
        try
        {
            stream = assembly.GetManifestResourceStream(resourceName);

            if(stream == null)
                throw new Exception("Failed creating resource stream from compiled resource: " + resourceName);

            reader = new StreamReader(stream);
            var trafficTollJson = reader.ReadToEnd();
            return JsonSerializer.Deserialize<TrafficTollSpecification>(trafficTollJson) ?? throw new ArgumentNullException();
        }
        catch (Exception ex)
        {
            throw new TrafficTollDataRetrievalException($"Failed deserializing json file database {jsonDbName} to {nameof(TrafficTollSpecification)}", ex);
        }
        finally
        {
            reader?.Dispose();
            stream?.Dispose();
        }
    }

    private static TollCalculationParameters CreateTollCalculationParameters()
    {
        EnsureTrafficTypesExist(TrafficTollSpecification.PriceMapping);
        var tollFeeSpans = CreateTollFeeSpans(TrafficTollSpecification.DailyTollTimePrizes, TrafficTollSpecification.PriceMapping);
        var tollFreeDateTuples = TrafficTollSpecification.TollFreeDates.Select(x => (x.Year, x.Month, x.Day));

        return new TollCalculationParameters(TrafficTollSpecification.MaximumDailyFee, TrafficTollSpecification.ValidTollTime, tollFeeSpans);
    }

    private static IEnumerable<TollFeeSpan> CreateTollFeeSpans(IEnumerable<TollTimePeriod> dailyTollTimePrizes, Dictionary<int, int> trafficTypePrizeDictionary)
    {
        return dailyTollTimePrizes.Select(x => new TollFeeSpan(x.Start, x.End, trafficTypePrizeDictionary[x.TollTrafficType]));
    }

    private static void EnsureTrafficTypesExist(Dictionary<int, int> intPrizeDictionary)
    {
        var storedKeys = intPrizeDictionary.Keys.OrderBy(x => x);
        var applicationKeys = Enum.GetValues<TollTrafficType>().OfType<int>();

        if (NotAllStoredKeysIsRepresentedInApplication(storedKeys, applicationKeys))
            throw new InconsistentTrafficTollDataException($"{nameof(TollTrafficType)}");
    }

    private static bool NotAllStoredKeysIsRepresentedInApplication(IEnumerable<int> storedKeys, IEnumerable<int> applicationKeys)
    {
        return applicationKeys.Any(x => !storedKeys.Contains(x));
    }
}