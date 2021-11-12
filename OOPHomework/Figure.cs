using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPHomework
{
    public class Figure : IFigure
    {
        ConsoleColor Color { get; set; }
        bool Visible { get; set; }
        float _x { get; set; }
        float _y { get; set; }

        public string GetInfo()
        {
            throw new NotImplementedException();
        }

        public void HorizontalMove(float x)
        {
            throw new NotImplementedException();
        }

        public void Move(float x, float y)
        {
            throw new NotImplementedException();
        }

        public void SetColor(ConsoleColor color)
        {
            throw new NotImplementedException();
        }

        public void VerticalMove(float y)
        {
            throw new NotImplementedException();
        }
    }
    public class Point : Figure
    {

    }
}
