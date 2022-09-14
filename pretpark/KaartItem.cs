namespace Kaart
{
    public class KaartItem : Tekenbaar
    {
        private Coordinaat _locatie{get; set;}
        private Kaart kaart;
        private char Karakter{get;}

        public KaartItem(Kaart kaart, Coordinaat _locatie)
        {
            this._locatie = _locatie;
            this.kaart = kaart;
        }

        public void TekenConsole(ConsoleTekener t)
        {
            t.Teken(this);
        }
    }
}