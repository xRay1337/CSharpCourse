using System;

namespace Shapes
{
    interface IShape : IComparable
    {
        double GetWidth();
        double GetHeight();
        double GetArea();
        double GetPerimeter();
    }
}