using OOPHomework.Enum;
namespace OOPHomework.Figure;

/// <summary>Точка</summary>
public class Point : Figure
{
    FigureType Type = FigureType.Point;
    /// <summary>Создать точку в координатах (<paramref name="x"/>,<paramref name="y"/>)</summary>
    public Point(int x, int y) : base(x, y) { }
    /// <summary>Создать цветную точку в координатах <paramref name="position"/></summary>
    /// <param name="position">Координаты (x,y)</param><param name="color">Цвет</param>
    public Point((int x, int y) position, ConsoleColor color) : base(position, color) { }
    /// <summary>Вычислить площадь объекта</summary>
    public override float GetArea() => 0f;
    /// <summary>Информация об объекте</summary>
    /// <returns>Цвет, видимость, координаты</returns>
    public override string GetInfo() => $"Color: {(Color == null ? "not colored" : Color)},Visible: {Visible}, Coordinates (x|y): ({_x}|{_y})";
}
