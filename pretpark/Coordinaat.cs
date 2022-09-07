namespace Kaart
{
    public struct Coordinaat
    {
        public readonly int x;
        public readonly int y;

        public Coordinaat(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public static Coordinaat operator+(Coordinaat a, Coordinaat b)
        {
            return new Coordinaat((a.x + b.x), (a.y + b.y));
        }

        public static Coordinaat operator-(Coordinaat a, Coordinaat b)
        {
            return new Coordinaat((a.x - b.x), (a.y - b.y));
        }
    }
}