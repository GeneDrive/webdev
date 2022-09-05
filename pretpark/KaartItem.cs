using static Tekenbaar;
public class KaartItem : Tekenbaar
{
    private Coordinaat _locatie{get; set;}
    private Kaart kaart;
    private char Karakter{get;}

    public KaartItem(Coordinaat _locatie, Kaart kaart)
    {
        this._locatie = _locatie;
        this.kaart = kaart;
    }

    public void TekenConsole(ConsoleTekener t)
    {
        // write character
    }
}