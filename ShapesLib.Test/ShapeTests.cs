using ShapesLib.Shapes;

namespace ShapesLib.Test;

public class ShapeTests
{
    //1.3 Возможность создания любой фигуры
    [Fact]
    public void Triangle_and_circle_are_shapes()
    {
        // Arrange
        var triangle = new Triangle(sideA: 3, sideB: 4, sideC: 5);
        var cirlce = new Circle(1);

        // Act and Assert
        triangle.Should().BeAssignableTo<IShape>();
        cirlce.Should().BeAssignableTo<IShape>();
    }
}