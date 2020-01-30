using System;

namespace Shapes
{
    class Triangle : IShape
    {
        private double x1 { get; set; }
        private double y1 { get; set; }
        private double x2 { get; set; }
        private double y2 { get; set; }
        private double x3 { get; set; }
        private double y3 { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
        }

        public double GetArea()
        {
            double epsilon = 1.0e-10;

            if (Math.Abs((x3 - x1) * (y2 - y1) - (y3 - y1) * (x2 - x1)) < epsilon)
            {
                return 0;
            }
            else
            {
                double sideAB = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
                double sideBC = Math.Sqrt(Math.Pow(x2 - x3, 2) + Math.Pow(y2 - y3, 2));
                double sideCA = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));

                double halfPerimeter = (sideAB + sideBC + sideCA) / 2;
                double triangleArea = Math.Sqrt(halfPerimeter * (halfPerimeter - sideAB) * (halfPerimeter - sideBC) * (halfPerimeter - sideCA));

                return triangleArea;
            }
        }

        public double GetPerimeter()
        {
            double sideAB = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            double sideBC = Math.Sqrt(Math.Pow(x2 - x3, 2) + Math.Pow(y2 - y3, 2));
            double sideCA = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));

            return sideAB + sideBC + sideCA;
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(y1, y2), y3) - Math.Min(Math.Min(y1, y2), y3);
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(x1, x2), x3) - Math.Min(Math.Min(x1, x2), x3);
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
            int prime = 37;
            int hash = 1;

            hash = prime * hash + (int)x1;
            hash = prime * hash + (int)x2;
            hash = prime * hash + (int)x3;
            hash = prime * hash + (int)y1;
            hash = prime * hash + (int)y2;
            hash = prime * hash + (int)y3;

            hash = prime * hash + GetArea().GetHashCode();

            return hash;
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