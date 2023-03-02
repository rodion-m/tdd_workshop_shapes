namespace ShapesLib.Shapes;

/// <summary>
/// Represents a circle.
/// </summary>
public class Circle : IShape
{
    private readonly double _radius;

    /// <summary>
    /// Initializes a new instance of the <see cref="Circle"/> class with the specified radius.
    /// </summary>
    /// <param name="radius">The radius of the circle.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the radius is not greater than zero.</exception>
    public Circle(double radius)
    {
        if (double.IsNaN(radius) || double.IsInfinity(radius) || radius <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be greater than zero.");
        }

        _radius = radius;
    }

    /// <summary>
    /// Gets the radius of the circle.
    /// </summary>
    public double Radius => _radius;

    /// <summary>
    /// Calculates the area of the circle.
    /// </summary>
    /// <returns>The area of the circle.</returns>
    public double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}