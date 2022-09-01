using static Tekenbaar;
class Pad : Tekenbaar
{
    private float ?lengteBerekend;

    public float Lengte()
    {
        return (float) lengteBerekend;
    }

    public float Afstand(Coordinaat c)
    {
        return;
    }

    public void TekenConsole(ConsoleTekener t)
    {

    }
}