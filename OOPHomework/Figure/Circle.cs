using OOPHomework.Enum;
namespace OOPHomework.Figure;

/// <summary>Круг</summary>
public class Circle : Point
{
    FigureType Type = FigureType.Flat;
    float Radius { get; set; }
    private Circle(int x, int y) : base(x, y) { }
    /// <summary>Создать круг в координатах <paramref name="position"/> радиусом <paramref name="radius"/></summary>
    /// <param name="radius">Радиус</param><param name="position">Координаты</param>
    public Circle(float radius, (int x, int y) position) : this(position.x, position.y) => Radius = radius;
    /// <summary>Создать цветной круг в координатах <paramref name="position"/> радиусом <paramref name="radius"/></summary>
    /// <param name="radius">Радиус</param><param name="position">Координаты</param><param name="color">Цвет</param>
    public Circle(float radius, (int x, int y) position, ConsoleColor color) : base(position, color) => Radius = radius;
    /// <summary>Вычислить площадь круга</summary>
    public override float GetArea() => 3.14f * Radius;
}
