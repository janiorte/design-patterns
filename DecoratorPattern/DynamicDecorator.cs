using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DecoratorPattern
{
    public abstract class Shape
    {
        public abstract string AsString();
    }

    public class Circle : Shape
    {
        private float radius;

        public Circle(): this(0)
        {

        }

        public Circle(float radius)
        {
            this.Radius = radius;
        }

        public float Radius { get => radius; set => radius = value; }

        public override string AsString() => $"A circle with radius {Radius}";

        public void Resize(float factor)
        {
            Radius *= factor;
        }
    }

    public class Square : Shape
    {
        private float side;

        public override string AsString() => $"A square with side {side}";

        public Square() : this(0.0f)
        {

        }

        public Square(float side)
        {
            this.side = side;
        }
    }

    public class ColoredShape : Shape
    {
        private Shape shape;
        public string color;

        public ColoredShape(Shape shape, string color)
        {
            this.shape = shape ?? throw new ArgumentNullException(nameof(shape));
            this.color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public override string AsString() => $"{shape.AsString()} has the color {color}";
    }

    public class TransparentShape : Shape
    {
        private Shape shape;
        private float transparency;

        public TransparentShape(Shape shape, float transparency)
        {
            this.shape = shape ?? throw new ArgumentNullException(nameof(shape));
            this.transparency = transparency;
        }

        public override string AsString() => $"{shape.AsString()} has {transparency * 100.0}% transparency";
    }

    public class ColoredShape<T> : Shape where T : Shape, new()
    {
        private string color;
        private T shape = new T();

        public ColoredShape() : this("black")
        {

        }

        public ColoredShape(string color)
        {
            this.color = color ?? throw new ArgumentNullException(nameof(color));
        }

        public override string AsString() => $"{shape.AsString()} has the color {color}";
    }

    public class TransparentShape<T> : Shape where T : Shape, new()
    {
        private float transparency;
        private T shape = new T();

        public TransparentShape() : this(0)
        {

        }

        public TransparentShape(float transparency)
        {
            this.transparency = transparency;
        }

        public override string AsString() => 
            $"{shape.AsString()} has {transparency * 100.0f}% transparency";
    }

    static class DynamicDecorator
    {
        static void Main(string[] args)
        {
            var square = new Square(1.23f);
            WriteLine(square.AsString());

            var redSquare = new ColoredShape(square, "red");
            WriteLine(redSquare.AsString());

            var redHalfTransparentSquare = new TransparentShape(redSquare, 0.5f);
            WriteLine(redHalfTransparentSquare.AsString());

            var redSquare2 = new ColoredShape<Square>("red");
            WriteLine(redSquare2.AsString());

            var circle = new TransparentShape<ColoredShape<Circle>>(0.4f);
            WriteLine(circle.AsString());
        }
    }
}
