namespace ShapesLib.Shapes;

public class Triangle : IShape
{
    internal const string TriangleWithGivenSidesDoesntExist = "Triangle with given sides doesn't exist!";
    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }
    
    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA is <= 0 or double.NaN || double.IsInfinity(sideA)) 
            throw new ArgumentOutOfRangeException(nameof(sideA));
        if (sideB is <= 0 or double.NaN || double.IsInfinity(sideB)) 
            throw new ArgumentOutOfRangeException(nameof(sideB));
        if (sideC is <= 0 or double.NaN || double.IsInfinity(sideC)) 
            throw new ArgumentOutOfRangeException(nameof(sideC));
        
        if (!Exists(sideA, sideB, sideC))
        {
            throw new ArgumentException(TriangleWithGivenSidesDoesntExist);
        }

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }
    
    internal static bool Exists(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }

    /// <summary>
    /// Calculates the area of the triangle using Heron's formula.
    /// </summary>
    /// <returns>The area of the triangle.</returns>
    public double GetArea()
    {
        double s = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    /// <summary>
    /// Determines whether the triangle is a right triangle.
    /// </summary>
    /// <returns>True if the triangle is a right triangle, false otherwise.</returns>
    public bool IsRightTriangle()
    {
        double[] sides = { SideA, SideB, SideC };
        Array.Sort(sides);
        return Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 0.0001;
    }
}