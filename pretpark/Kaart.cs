using static Tekener;
public class Kaart : Tekener
{
    public readonly int Breedte;
    public readonly int Hoogte;
    public List<KaartItem> Items = new List<KaartItem>();
    public List<Pad> Paden = new List<Pad>();

    public Kaart(int _Breedte, int _Hoogte)
    {
        Breedte = _Breedte;
        Hoogte = _Hoogte;
    }

    public void Teken(Tekener t)
    {
        
    }

    public void VoegItemToe(KaartItem item)
    {
        Items.Add(item);
    }

    public void VoegPadToe(Pad pad)
    {
        Paden.Add(pad);
    }
}