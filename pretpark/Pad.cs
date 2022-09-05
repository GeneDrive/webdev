using static Tekenbaar;
public class Pad : Tekenbaar
{
    private float? _lengteBerekend;
    private float? lengteBerekend {
        get
        {
            return _lengteBerekend;
        }
        set
        {
            _lengteBerekend = value;
        }
    }
    private Coordinaat _van;
    public Coordinaat van{
        get
        {
            return _van;
        }
        set
        {
            if(value.x < 0 || value.y < 0)
                throw new Exception("de waardes mogen niet negatief zijn");

            lengteBerekend = null;
            _van = value;
        }
    }

    private Coordinaat _naar;
    public Coordinaat naar{
        get
        {
            return _naar;
        }
        set
        {
            if(value.x < 0 || value.y < 0)
                throw new Exception("de waardes mogen niet negatief zijn");

            lengteBerekend = null;
            _naar = value;
        }
    }

    public float Lengte()
    {
        var hoogte = naar.y - van.y;
        var lengte = naar.x - van.x;
        var afstand = Math.Sqrt(Math.Pow(hoogte, 2) + Math.Pow(lengte, 2));

        return (float) afstand;
    }

    public void TekenConsole(ConsoleTekener t)
    {
        // zet hier de complece teken
    }
}