using static Tekener;
public class Kaart : Tekener
{
    public readonly int Breedte;
    public readonly int Hoogte;
    public readonly IList<T> Items = new List<T>();
    public readonly IList<T> Paden = new List<T>();

    public Kaart(int _Breedte, int _Hoogte)
    {
        Breedte = _Breedte;
        Hoogte = _Hoogte;
    }

    public void Teken(Tekener t)
    {
        
    }

    public void VoegItemToe(/*KaartItem item*/)
    {

    }

    public void VoegPadToe(/*Pad pad*/)
    {

    }
}