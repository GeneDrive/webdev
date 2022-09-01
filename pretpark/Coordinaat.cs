public struct Coordinaat
{
    public readonly int x;
    public readonly int y;

    public Coordinaat(int _x, int _y)
    {
        x = _x;
        y = _y;
    }

    public Coordinaat operator+(Coordinaat c, Coordinaat x)
    {
        return c;
    }
}