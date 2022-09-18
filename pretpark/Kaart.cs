namespace Kaart
{
    public class Kaart
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
            foreach(var pad in Paden) {
                t.Teken(pad);
            }
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
}