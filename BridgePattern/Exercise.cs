using NUnit.Framework;
using System;

namespace Coding.Exercise
{
    public interface IRenderer
    {
        string WhatToRenderAs();
    }

    public abstract class Shape
    {
        public string Name { get; set; }
        public IRenderer Renderer { get; set; }

        protected Shape(IRenderer renderer)
        {
            Renderer = renderer;
        }

        public override string ToString()
        {
            return $"Drawing {Name} as {Renderer.WhatToRenderAs()}";
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer)
        {
            Name = "Triangle";
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer)
        {
            Name = "Square";
        }
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs()
        {
            return "lines";
        }
    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs()
        {
            return "pixels";
        }
    }

    [TestFixture]
    public class TestSuite
    {
        [Test]
        public void Test()
        {
            Assert.That(
              new Square(new VectorRenderer()).ToString(),
              Is.EqualTo("Drawing Square as lines"));
        }
    }
}

