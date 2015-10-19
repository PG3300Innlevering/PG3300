namespace SnakeMess
{
    public class Coord
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coord()
        {
            X = 0;
            Y = 0;
        }

        public Coord(Coord input)
        {
            X = input.X;
            Y = input.Y;
        }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}