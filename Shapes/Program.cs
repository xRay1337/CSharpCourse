using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Square square1 = new Square(5);
            Square square2 = new Square(9);

            Triangle triangle1 = new Triangle(0, 0, 0, 5, 5, 0);
            Triangle triangle2 = new Triangle(0, 0, 0, 9, 9, 0);

            Rectangle rectangle1 = new Rectangle(4, 9);
            Rectangle rectangle2 = new Rectangle(5, 9);

            Circle circle1 = new Circle(5);
            Circle circle2 = new Circle(9);

            IShape[] shapes = new IShape[8];

            shapes[0] = square1;
            shapes[1] = square2;
            shapes[2] = triangle1;
            shapes[3] = triangle2;
            shapes[4] = rectangle1;
            shapes[5] = rectangle2;
            shapes[6] = circle1;
            shapes[7] = circle2;

            Array.Sort(shapes);

            Console.WriteLine("Первая фигура по площади: {0}", shapes[shapes.Length - 1].ToString());
            Console.WriteLine("Вторая фигура по площади: {0}", shapes[shapes.Length - 2].ToString());

            Console.ReadKey();
        }
    }
}