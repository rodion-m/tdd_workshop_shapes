using ShapesLib.Shapes;

namespace ShapesLib.Test;

public class CircleTests
{
    [Fact]
    public void Circle_created()
    {
        // Arrange
        var radius = 1d;

        // Act
        var circle = new Circle(radius: radius);

        // Assert
        circle.Radius.Should().Be(radius);
    }
    
    [Theory]
    [InlineData(double.NaN)]
    [InlineData(double.PositiveInfinity)]
    [InlineData(double.NegativeInfinity)]
    [InlineData(0)]
    [InlineData(-1)]
    public void Creating_invalid_circle_is_impossible(double radius)
    {
        FluentActions.Invoking(() => new Circle(radius))
            .Should()
            .Throw<ArgumentOutOfRangeException>()
            .WithParameterName("radius", "because radius is invalid");
    }

    [Theory]
    [InlineData(1, Math.PI)]
    [InlineData(5.5, 95.033177771091246)]
    public void Area_calculation_is_correct(double radius, double expectedArea)
    {
        var circle = new Circle(radius);
        circle.GetArea().Should()
            .BeApproximately(expectedArea, 0.000000001);
    }
}