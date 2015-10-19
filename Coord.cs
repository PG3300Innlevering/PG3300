public class Coord
{

    public const string Ok = "Ok";

    public int x;
    public int y;

    public Coord()
    {
        Coord(0, 0);
    }

    public Coord(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Coord(Coord input)
    {
        this.x = input.x;
        this.y = input.y;
    }

}
