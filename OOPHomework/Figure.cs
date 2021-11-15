using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OOPHomework;

    public enum FigureType
{
    Flat,
    Volumetric,
    Point,
    Polygon
}
public abstract class Figure : IFigure
{
    public ConsoleColor Color { get; private set; }
    public bool Visible { get; private set; }
    public float _x { get; private set; }
    public float _y { get; private set; }

    public Figure(int x, int y) { _x = x; _y = y; }
    public Figure((int x, int y) position, ConsoleColor color) : this(position.x, position.y) => Color = color;

    public abstract string GetInfo(); //=> $"Color: {Color},Visible: {Visible}, Coordinates (x|y): ({_x}|{_y})";
    public void SetColor(ConsoleColor color) => Color = color;
    public void Move(float x, float y) { _x = x; _y = y; }
    public void HorizontalMove(float x) => _x = x;
    public void VerticalMove(float y) => _y = y;
}
public class Point : Figure
{
    FigureType Type = FigureType.Flat;
    public Point(int x, int y) : base(x, y) { }
    public Point((int x, int y) position, ConsoleColor color) : base(position, color) { }

    public override string GetInfo() => $"Color: {Color},Visible: {Visible}, Coordinates (x|y): ({_x}|{_y})";
}
public class Circle : Point
{
    FigureType Type = FigureType.Flat;
    float Radius { get; set; }
    private Circle(int x, int y) : base(x, y) { }
    public Circle(float radius, (int x, int y) position) : this(position.x, position.y) => Radius = radius;
    public Circle(float radius, (int x, int y) position, ConsoleColor color) : base(position, color) => Radius = radius;
}