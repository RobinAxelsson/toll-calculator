﻿namespace toll_calculator.models;

internal sealed class TrafficTollSpecification
{
    public TrafficTollSpecification(DateTime validFrom, DateTime validUntil, int maximumDailyFee, TollTimePrize[] dailyTollTimePrizes, DateTime[] tollFreeDates, int[] tollFreeVehicleTypes)
    {
        ValidFrom = validFrom;
        ValidUntil = validUntil;
        MaximumDailyFee = maximumDailyFee;
        DailyTollTimePrizes = dailyTollTimePrizes;
        TollFreeDates = tollFreeDates;
        TollFreeVehicleTypes = tollFreeVehicleTypes;
    }

    public DateTime ValidFrom { get; }
    public DateTime ValidUntil { get; }
    public int MaximumDailyFee { get; }
    public TollTimePrize[] DailyTollTimePrizes { get; }
    public DateTime[] TollFreeDates { get; }
    public int[] TollFreeVehicleTypes { get; }
}