using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPHomework
{
    internal interface IFigure
    {
        public void Move(float x, float y);
        public void VerticalMove(float y);
        public void HorizontalMove(float x);
        public string GetInfo();
        public void SetColor(ConsoleColor color);
    }
}
