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
    public void Calculate_for_car_and_friday_09_00()
    {
        // Arrange
        var car = new Car();
        var tollCalc = new TollCalculator();
        var fridayMay3rd = new DateTime(2013, 5, 3, 9, 0, 0);

        // Act
        var result = tollCalc.GetTollFee(fridayMay3rd, car);


        // Assert
        result.Should().Be(8);
    }

    [Fact]
    public void Calculate_05_00_for_car_and_friday_May_3rd_2013()
    {
        // Arrange & Act & Assert
        CalculateCarTollFridayOfMay2013AtTime(5, 0, 0).Should().Be(0);
    }
    [Fact]
    public void Calculate_06_00_for_car_and_friday_May_3rd_2013()
    {
        // Arrange & Act & Assert
        CalculateCarTollFridayOfMay2013AtTime(6, 0, 0).Should().Be(8);
    }
    [Fact]
    public void Calculate_06_30_for_car_and_friday_May_3rd_2013()
    {
        // Arrange & Act & Assert
        CalculateCarTollFridayOfMay2013AtTime(6, 30, 0).Should().Be(13);
    }

    [Fact]
    public void Calculate_07_00_for_car_and_friday_May_3rd_2013()
    {
        // Arrange & Act & Assert
        CalculateCarTollFridayOfMay2013AtTime(7, 0, 0).Should().Be(18);
    }

    [Fact]
    public void Calculate_08_00_for_car_and_friday_May_3rd_2013()
    {
        // Arrange & Act & Assert
        CalculateCarTollFridayOfMay2013AtTime(8, 0, 0).Should().Be(13);
    }

    [Fact]
    public void Calculate_08_30_for_car_and_friday_May_3rd_2013()
    {
        // Arrange & Act & Assert
        CalculateCarTollFridayOfMay2013AtTime(8, 0, 0).Should().Be(13);
    }

    [Fact]
    public void Calculate_09_to_15_for_car_and_friday_May_3rd_2013()
    {
        // Arrange & Act & Assert
        CalculateCarTollFridayOfMay2013AtTime(9,0,0).Should().Be(8);
        CalculateCarTollFridayOfMay2013AtTime(10,0,0).Should().Be(8);
        CalculateCarTollFridayOfMay2013AtTime(11,0,0).Should().Be(8);
        CalculateCarTollFridayOfMay2013AtTime(12,0,0).Should().Be(8);
        CalculateCarTollFridayOfMay2013AtTime(13,0,0).Should().Be(8);
        CalculateCarTollFridayOfMay2013AtTime(14,0,0).Should().Be(8);
        CalculateCarTollFridayOfMay2013AtTime(14,59,59).Should().Be(8);
    }

    [Fact]
    public void Calculate_15_00_for_car_and_friday_May_3rd_2013()
    {
        // Arrange & Act & Assert
        CalculateCarTollFridayOfMay2013AtTime(15, 0, 0).Should().Be(13);
    }

    [Fact]
    public void Calculate_15_29_for_car_and_friday_May_3rd_2013()
    {
        // Arrange & Act & Assert
        CalculateCarTollFridayOfMay2013AtTime(15, 29, 59).Should().Be(13);
    }

    [Fact]
    public void Calculate_15_30_for_car_and_friday_May_3rd_2013()
    {
        // Arrange & Act & Assert
        CalculateCarTollFridayOfMay2013AtTime(15, 30, 0).Should().Be(18);
    }

    [Fact]
    public void Calculate_16_00_for_car_and_friday_May_3rd_2013()
    {
        // Arrange & Act & Assert
        CalculateCarTollFridayOfMay2013AtTime(16, 0, 0).Should().Be(18);
    }

    [Fact]
    public void Calculate_16_59_for_car_and_friday_May_3rd_2013()
    {
        // Arrange & Act & Assert
        CalculateCarTollFridayOfMay2013AtTime(16, 59, 59).Should().Be(18);
    }


    [Fact]
    public void Calculate_17_00_for_car_and_friday_May_3rd_2013()
    {
        // Arrange & Act & Assert
        CalculateCarTollFridayOfMay2013AtTime(17, 0, 0).Should().Be(13);
    }

    [Fact]
    public void Calculate_18_00_for_car_and_friday_May_3rd_2013()
    {
        // Arrange & Act & Assert
        CalculateCarTollFridayOfMay2013AtTime(18, 0, 0).Should().Be(8);
    }

    [Fact]
    public void Calculate_18_29_for_car_and_friday_May_3rd_2013()
    {
        // Arrange & Act & Assert
        CalculateCarTollFridayOfMay2013AtTime(18, 29, 59).Should().Be(8);
    }

    [Fact]
    public void Calculate_19_00_to_04_for_car_and_friday_May_3rd_2013()
    {
        // Arrange & Act & Assert
        CalculateCarTollFridayOfMay2013AtTime(19, 0, 0).Should().Be(0);
        CalculateCarTollFridayOfMay2013AtTime(20, 0, 0).Should().Be(0);
        CalculateCarTollFridayOfMay2013AtTime(21, 0, 0).Should().Be(0);
        CalculateCarTollFridayOfMay2013AtTime(22, 0, 0).Should().Be(0);
        CalculateCarTollFridayOfMay2013AtTime(23, 0, 0).Should().Be(0);
        CalculateCarTollFridayOfMay2013AtTime(23, 59, 59).Should().Be(0);
        CalculateCarTollFridayOfMay2013AtTime(0, 0, 0).Should().Be(0);
        CalculateCarTollFridayOfMay2013AtTime(1, 0, 0).Should().Be(0);
        CalculateCarTollFridayOfMay2013AtTime(2, 0, 0).Should().Be(0);
        CalculateCarTollFridayOfMay2013AtTime(3, 0, 0).Should().Be(0);
        CalculateCarTollFridayOfMay2013AtTime(4, 0, 0).Should().Be(0);
    }


    private static int CalculateCarTollFridayOfMay2013AtTime(int hour, int minute, int second)
    {
        // Arrange
        var car = new Car();
        var sut = new TollCalculator();
        var fridayMay3rd = new DateTime(2013, 5, 3, hour, minute, second);

        // Act
        return sut.GetTollFee(fridayMay3rd, car);
    }
}