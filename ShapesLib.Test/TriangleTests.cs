using ShapesLib.Shapes;
using static FluentAssertions.FluentActions;

namespace ShapesLib.Test;

public class TriangleTests
{
    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(5, 12, 13)]
    [InlineData(8, 15, 17)]
    public void Triangle_created(double a, double b, double c) //happy path
    {
        var triangle = new Triangle(sideA: a, sideB: b, sideC: c);
        triangle.SideA.Should().Be(a);
        triangle.SideB.Should().Be(b);
        triangle.SideC.Should().Be(c);
    }

    [Fact]
    public void Invalid_triangle_creating_is_impossible()
    {
        var act = () => new Triangle(sideA: 1, sideB: 2, sideC: 3);
        act.Should()
            .ThrowExactly<ArgumentException>("because triangle with given sides doesnt exist")
            .WithMessage(Triangle.TriangleWithGivenSidesDoesntExist);
    }

    [Theory]
    [InlineData(double.NaN, 4, 5)]
    [InlineData(double.PositiveInfinity, 4, 5)]
    [InlineData(1, double.NaN, 5)]
    [InlineData(1, 2, double.NaN)]
    [InlineData(0, 4, 5)]
    [InlineData(-1, 4, 5)]
    public void Triangle_with_negative_size_creating_is_impossible(
        double sideA, double sideB, double sideC)
    {
        Invoking(() => new Triangle(sideA, sideB, sideC))
            .Should()
            .Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(3, 4, 5, 6)]
    [InlineData(5, 12, 13, 30)]
    [InlineData(8, 15, 17, 60)]
    public void Triangle_are_calculation_is_correct(
        double sideA, double sideB, double sideC, double expectedArea)
    {
        var triangle = new Triangle(sideA, sideB, sideC);
        triangle.GetArea().Should().BeApproximately(expectedArea, 0.00000001);
    }

    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(5, 12, 13, true)]
    [InlineData(8, 15, 17, true)]
    [InlineData(3, 4, 6, false)]
    [InlineData(5, 12, 14, false)]
    [InlineData(8, 15, 18, false)]
    public void Triangle_rightness_checking_is_correct(
        double sideA, double sideB, double sideC, bool expected)
    {
        var triangle = new Triangle(sideA, sideB, sideC);
        triangle.IsRightTriangle().Should().Be(expected);
    }
    
    [Theory]
    [InlineData(3, 4, 5, true)] //1.2.1 happy path
    [InlineData(1, 2, 3, false)] //1.2.1
    [InlineData(-1, 1, 1, false)] //1.2.2
    [InlineData(0, 1, 1, false)] //1.2.2
    [InlineData(-3, -4, -10, false)]
    [InlineData(0, 1, 2, false)]
    [InlineData(double.NaN, 1, 2, false)]
    [InlineData(double.NaN, double.NaN, double.NaN, false)]
    [InlineData(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, false)]
    public void Triangle_existance_checking_is_correct(double a, double b, double c, bool expected)
    {
        // избыточный тест приватного метода, он не нужен.
        Triangle.Exists(a, b, c).Should().Be(expected);
    }
}