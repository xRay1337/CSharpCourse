using System;

namespace Shapes
{
    class Rectangle : IShape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double GetArea()
        {
            return Height * Width;
        }

        public double GetPerimeter()
        {
            return (Height + Width) * 2;
        }

        public double GetHeight()
        {
            return Height;
        }

        public double GetWidth()
        {
            return Width;
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
            return string.Format("{0}. Height = {1:f2}. Width = {2:f2}. Area = {3:f2}. Perimeter = {4:f2}.", GetType(), Height, Width, GetArea(), GetPerimeter());
        }

        public override int GetHashCode()
        {
            int prime = 47;
            int hash = 1;

            hash = prime * hash + Height.GetHashCode();

            hash = prime * hash + Width.GetHashCode();

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

            Rectangle rectangle = (Rectangle)obj;

            return Height == rectangle.Height && Width == rectangle.Width;
        }
    }
}