using Shapes.Comparers;
using Shapes.Shapes;
using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapes = {
                new Square(5) ,
                new Square(9) ,
                new Triangle(0, 0, 0, 5, 5, 0),
                new Triangle(0, 0, 0, 9, 9, 0),
                new Rectangle(4, 9),
                new Rectangle(5, 9),
                new Circle(5),
                new Circle(9)
            };

            AreaComparer areaComparer = new AreaComparer();
            Array.Sort(shapes, areaComparer);
            Console.WriteLine("Первая фигура по площади: {0}", shapes[shapes.Length - 1]);
            Console.WriteLine();

            PerimeterComparer perimeterComparer = new PerimeterComparer();
            Array.Sort(shapes, perimeterComparer);
            Console.WriteLine("Вторая фигура по периметру: {0}", shapes[shapes.Length - 2]);

            Console.ReadKey();
        }
    }
}