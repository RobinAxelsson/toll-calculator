using FluentAssertions;
using toll_calculator.models;
using Xunit;

namespace toll_calculator.tests;


public class ClassTests
{
    //Fees will differ between 8 SEK and 18 SEK, depending on the time of day

    [Fact]
    public void GetTollFee_car_one_passing_all_ranges_happy_path()
    {
        TestCarToll(5, 59).Should().Be(0);
        TestCarToll(6, 0).Should().Be(Toll.LowTraffic);
        TestCarToll(6, 29).Should().Be(Toll.LowTraffic);
        TestCarToll(6, 30).Should().Be(Toll.MidTraffic);
        TestCarToll(6, 59).Should().Be(Toll.MidTraffic);
        TestCarToll(7, 0).Should().Be(Toll.RushHourTraffic);
        TestCarToll(7, 59).Should().Be(Toll.RushHourTraffic);
        TestCarToll(8, 0).Should().Be(Toll.MidTraffic);
        TestCarToll(8, 30).Should().Be(Toll.LowTraffic);
        TestCarToll(8, 30).Should().Be(Toll.LowTraffic);
        TestCarToll(14, 59).Should().Be(Toll.LowTraffic);
        TestCarToll(15, 00).Should().Be(Toll.MidTraffic);
        TestCarToll(14, 59).Should().Be(Toll.LowTraffic);
        TestCarToll(15, 0).Should().Be(Toll.MidTraffic);
        TestCarToll(15, 29).Should().Be(Toll.MidTraffic);
        TestCarToll(16, 0).Should().Be(Toll.RushHourTraffic);
        TestCarToll(16, 59).Should().Be(Toll.RushHourTraffic);
        TestCarToll(17, 00).Should().Be(Toll.MidTraffic);
        TestCarToll(17, 59).Should().Be(Toll.MidTraffic);
        TestCarToll(18, 00).Should().Be(Toll.LowTraffic);
        TestCarToll(18, 29).Should().Be(Toll.LowTraffic);
        TestCarToll(18, 30).Should().Be(0);
    }

    private int TestCarToll(int hours, int minutes, int seconds = 0)
    {
        var car = new Car();
        var passing = new DateTime(2022, 12, 19, hours, minutes, seconds, DateTimeKind.Local);
        return TollTimeOfDayCalculator.GetTollFee(passing);
    }
}
