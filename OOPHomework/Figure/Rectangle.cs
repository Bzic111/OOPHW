using OOPHomework.Enum;
namespace OOPHomework.Figure;

/// <summary>Прямоуголник</summary>
public class Rectangle : Point
{
    FigureType Type = FigureType.Flat;
    /// <summary>Длина параллельных сторон A B</summary>
    public float AB { get; private set; }
    /// <summary>Длина параллельных сторон C D</summary>
    public float CD { get; private set; }
    /// <summary>Создать Прямоуголник в координатах (<paramref name="x"/>,<paramref name="y"/>)</summary>
    public Rectangle(int x, int y) : base(x, y) { }
    /// <summary>Создать цветной Прямоуголник в координатах <paramref name="position"/></summary>
    /// <param name="position">Координаты</param><param name="color">Цвет</param>
    public Rectangle((int x, int y) position, ConsoleColor color) : base(position, color)
    {
    }
    /// <summary>Создать Прямоуголник в координатах (<paramref name="x"/>,<paramref name="y"/>)
    /// со сторонами <paramref name="ab"/> и <paramref name="cd"/></summary><param name="position">Координаты</param>
    /// <param name="ab">Длина параллельных сторон <paramref name="ab"/></param>
    /// <param name="cd">Длина параллельных сторон <paramref name="cd"/></param>
    public Rectangle((int x, int y) position, float ab, float cd) : base(position.x, position.y)
    {
        AB = ab; CD = cd;
    }
    /// <summary>Вычислить площадь прямоугольника</summary>
    public override float GetArea() => AB * CD;
}