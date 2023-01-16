using FluentAssertions;
using toll_calculator.models;
using Xunit;

namespace toll_calculator.tests;


public class ClassTest_TollCalculatorTests
{

    [Fact]
    public void Create_class()
    {
        // Arrange & Act
        var tollCalc = new TollCalculator();

        // Assert
        tollCalc.Should().NotBeNull();
    }

    [Fact]
    public void Create_car()
    {
        // Arrange & Act
        var car = new Car();


        // Assert
        car.Should().NotBeNull();
    }

    [Fact]
    public void Calculate_for_car_and_date()
    {
        // Arrange
        var car = new Car();
        var tollCalc = new TollCalculator();
        var fridayMay3rd = new DateTime(2013, 5, 3, 9, 0, 0);

        // Act
        var result = tollCalc.GetTollFee(fridayMay3rd, car);


        // Assert
        result.Should().BeGreaterThan(0);
    }
}