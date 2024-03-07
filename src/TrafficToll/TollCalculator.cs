using TrafficToll.Internals.DataAccess;
using TrafficToll.Internals.Enums;
using TrafficToll.Internals.Services;
using TrafficToll.Internals.Validators;

namespace TrafficToll
{
    public class TollCalculator
    {
        private TollCalculatorCore _tollCalculatorCore;
        private TollPassingVerifyer _tollPassingVerifyer;

        public TollCalculator() : this(new TollPassingVerifyer(TrafficTollDataManager.GetTollFreeParameters()), new TollCalculatorCore(TrafficTollDataManager.GetTollCalculationParameters())){}

        private TollCalculator(TollPassingVerifyer tollPassingVerifyer, TollCalculatorCore tollCalculatorCore)
        {
            _tollPassingVerifyer = tollPassingVerifyer;
            _tollCalculatorCore = tollCalculatorCore;
        }

        public int GetTollFee(IEnumerable<DateTime> passings, int vehicleType)
        {
            passings = passings.ToArray();
            
            ValidatorCalculationArguments.EnsureArgumentsIsValid(passings, vehicleType);
            
            var tollablePassings = _tollPassingVerifyer.GetTollablePassings(passings, (VehicleType)vehicleType).ToArray();
            
            if (!tollablePassings.Any()) return 0;
            
            return _tollCalculatorCore.CalculateTollFee(tollablePassings);
        }
    }
}
