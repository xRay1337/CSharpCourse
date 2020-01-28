using System;

namespace Shapes
{
    class Rectangle : IShape
    {
        private double Height { get; set; }
        private double Width { get; set; }

        public Rectangle(double Height, double Width)
        {
            this.Height = Height;
            this.Width = Width;
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

        public int CompareTo(IShape shape)
        {
            if (this.GetArea() > shape.GetArea())
            {
                return 1;
            }

            if (this.GetArea() < shape.GetArea())
            {
                return -1;
            }

            return 0;
        }

        public int CompareTo(Object obj)
        {
            IShape shape = obj as IShape;

            if (this.GetArea() > shape.GetArea())
            {
                return 1;
            }

            if (this.GetArea() < shape.GetArea())
            {
                return -1;
            }

            return 0;
        }

        public override string ToString()
        {
            return string.Format("{0}. Area {1:f2}", this.GetType(), this.GetArea());
        }

        public override int GetHashCode()
        {
            return GetArea().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this.GetType() == obj.GetType())
            {
                IShape shape = obj as IShape;

                if (this.GetArea() == shape.GetArea())
                {
                    return true;
                }
            }

            return false;
        }
    }
}