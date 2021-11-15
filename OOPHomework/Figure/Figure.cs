using OOPHomework.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OOPHomework.Figure;

/// <summary>Абстрктная фигура</summary>
public abstract class Figure : IFigure
{
    /// <summary>Цвет</summary>
    public ConsoleColor? Color { get; private set; }
    /// <summary>Видимость</summary>
    public bool Visible { get; private set; }
    /// <summary>Координата Х</summary>
    public float _x { get; private set; }
    /// <summary>Координата Y</summary>
    public float _y { get; private set; }

#pragma warning disable CS1591
    public Figure(int x, int y) { _x = x; _y = y; }
    public Figure((int x, int y) position, ConsoleColor color) : this(position.x, position.y) => Color = color;
#pragma warning restore CS1591

    /// <summary>Информация об объекте</summary><returns>Цвет, видимость, координаты</returns>
    public abstract string GetInfo();
    /// <summary>Вычислить площадь объекта</summary>
    public abstract float GetArea();
    /// <summary>Задать Цвет <paramref name="color"/></summary>
    public void SetColor(ConsoleColor color) => Color = color;
    /// <summary>Переместить объект в координаты (<paramref name="x"/>,<paramref name="y"/>)</summary>
    public void Move(float x, float y) { _x = x; _y = y; }
    /// <summary>Переместить объект по горизонтали в координаты (<paramref name="x"/>)</summary>
    public void HorizontalMove(float x) => _x = x;
    /// <summary>Переместить объект по вертикали в координаты <paramref name="y"/></summary>
    public void VerticalMove(float y) => _y = y;
    /// <summary>Установить видимость объекта</summary>
    public void SetVisibility(bool visible) => Visible = visible;
}