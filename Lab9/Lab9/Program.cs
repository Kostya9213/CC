using System;
using System.Collections;
using System.Collections.Generic;

public abstract class Triangle
{
    public string Name { get; }
    public string Color { get; set; }
    public double SideLength { get; set; }
    public double OtherSideLength { get; set; }
    public double Angle { get; set; }

    protected Triangle(string name, double sideLength, double otherSideLength, double angle, string color)
    {
        Name = name;
        SideLength = sideLength;
        OtherSideLength = otherSideLength;
        Angle = angle;
        Color = color;
    }

    protected Triangle(string name, double sideLength, double otherSideLength, double angle)
        : this(name, sideLength, otherSideLength, angle, "Black")
    {
    }

    protected Triangle(string name, double sideLength, double otherSideLength)
        : this(name, sideLength, otherSideLength, 0)
    {
    }

    protected Triangle(string name, double sideLength)
        : this(name, sideLength, 0)
    {
    }

    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();
}

public class EqTriangle : Triangle, IDraw
{
    public EqTriangle(double sideLength, string color = "Black")
        : base("Equilateral Triangle", sideLength, sideLength, 60, color)
    {
    }

    public EqTriangle(string name, double sideLength, string color = "Black")
        : base(name, sideLength, sideLength, 60, color)
    {
    }

    public override double CalculateArea()
    {
        return (Math.Sqrt(3) / 4) * SideLength * SideLength;
    }

    public override double CalculatePerimeter()
    {
        return 3 * SideLength;
    }

    public void Draw()
    {
        Console.WriteLine($"Figure: {Name}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Side Length: {SideLength}");
        Console.WriteLine($"Area: {CalculateArea()}");
        Console.WriteLine($"Perimeter: {CalculatePerimeter()}");
        Console.WriteLine();
    }
}

public class IsTriangle : Triangle, IDraw
{
    public IsTriangle(double sideLength, double otherSideLength, string color = "Black")
        : base("Isosceles Triangle", sideLength, otherSideLength, 0, color)
    {
    }

    public IsTriangle(string name, double sideLength, double otherSideLength, string color = "Black")
        : base(name, sideLength, otherSideLength, 0, color)
    {
    }

    public override double CalculateArea()
    {
        return (SideLength / 4) * Math.Sqrt(4 * OtherSideLength * OtherSideLength - SideLength * SideLength);
    }

    public override double CalculatePerimeter()
    {
        return 2 * SideLength + OtherSideLength;
    }

    public void Draw()
    {
        Console.WriteLine($"Figure: {Name}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Side Length: {SideLength}");
        Console.WriteLine($"Other Side Length: {OtherSideLength}");
        Console.WriteLine($"Area: {CalculateArea()}");
        Console.WriteLine($"Perimeter: {CalculatePerimeter()}");
        Console.WriteLine();
    }
}

public class RectTriangle : Triangle, IDraw
{
    public RectTriangle(double sideLength, double otherSideLength, string color = "Black")
        : base("Right Triangle", sideLength, otherSideLength, 90, color)
    {
    }

    public RectTriangle(string name, double sideLength, double otherSideLength, string color = "Black")
        : base(name, sideLength, otherSideLength, 90, color)
    {
    }

    public override double CalculateArea()
    {
        return (SideLength * OtherSideLength) / 2;
    }

    public override double CalculatePerimeter()
    {
        return SideLength + OtherSideLength + Math.Sqrt(SideLength * SideLength + OtherSideLength * OtherSideLength);
    }

    public void Draw()
    {
        Console.WriteLine($"Figure: {Name}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Side Length: {SideLength}");
        Console.WriteLine($"Other Side Length: {OtherSideLength}");
        Console.WriteLine($"Angle: {Angle}");
        Console.WriteLine($"Area: {CalculateArea()}");
        Console.WriteLine($"Perimeter: {CalculatePerimeter()}");
        Console.WriteLine();
    }
}

public interface IDraw
{
    void Draw();
}

public class Picture : IDraw, IEnumerable<Triangle>
{
    private List<Triangle> collection;

    public int Count => collection.Count;

    public Picture()
    {
        collection = new List<Triangle>();
    }

    public Picture(int length)
    {
        collection = new List<Triangle>(length);
    }

    public void AddTriangle(Triangle triangle)
    {
        collection.Add(triangle);
    }

    public void RemoveTriangle(Triangle triangle)
    {
        collection.Remove(triangle);
    }

    public void RemoveTriangle(string name)
    {
        collection.RemoveAll(t => t.Name == name);
    }

    public void RemoveTrianglesLargerThanArea(double area)
    {
        collection.RemoveAll(t => t.CalculateArea() > area);
    }

    public Triangle this[int index]
    {
        get { return collection[index]; }
        set { collection[index] = value; }
    }

    public void Draw()
    {
        foreach (var triangle in collection)
        {
            if (triangle is IDraw drawableTriangle)
                drawableTriangle.Draw();
        }
    }

    public IEnumerator<Triangle> GetEnumerator()
    {
        return collection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Painter
{
    public static void DrawShapes(IDraw drawable)
    {
        drawable.Draw();
    }
}

public class Program
{
    public static void Main()
    {
        Picture picture = new Picture();
        picture.AddTriangle(new EqTriangle("Triangle 1", 5, "Red"));
        picture.AddTriangle(new IsTriangle(4, 6, "Blue"));
        picture.AddTriangle(new RectTriangle(3, 4, "Green"));

        Painter.DrawShapes(picture);
    }
}
