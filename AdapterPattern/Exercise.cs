using System;

namespace Coding.Exercise
{
    public class Square
    {
        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        private Square Square;

        public SquareToRectangleAdapter(Square square)
        {
            Square = square;
        }

        public int Width => Square.Side;

        public int Height => Square.Side;
    }
}
