using System;

namespace Shapes
{
    class Square : IShape
    {
        public double SideLength { get; set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public double GetArea()
        {
            return SideLength * SideLength;
        }

        public double GetPerimeter()
        {
            return 4 * SideLength;
        }

        public double GetHeight()
        {
            return SideLength;
        }

        public double GetWidth()
        {
            return SideLength;
        }

        public int CompareTo(object obj)
        {
            IShape shape = obj as IShape;

            if (GetArea() > shape.GetArea())
            {
                return 1;
            }

            if (GetArea() < shape.GetArea())
            {
                return -1;
            }

            return 0;
        }

        public override string ToString()
        {
            return string.Format("{0}. Side Length = {1:f2}. Area = {2:f2}. Perimeter = {3:f2}.", GetType(), SideLength, GetArea(), GetPerimeter());
        }

        public override int GetHashCode()
        {
            int prime = 47;
            int hash = 1;

            hash = prime * hash + SideLength.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Square square = (Square)obj;

            return SideLength == square.SideLength;
        }
    }
}