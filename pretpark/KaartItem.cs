namespace Kaart
{
    public class KaartItem : Tekenbaar
    {
        private Coordinaat _locatie;
        public Coordinaat locatie
        {
            get
            {
                return _locatie;
            } 
            set
            {
                if(value.x < 0 || value.y < 0)
                {
                    throw new Exception("negatief coordinaat mag niet bestaan");
                }

                _locatie = value;
            }
        }
        private Kaart kaart;
        private char Karakter{get;}

        public KaartItem(Kaart kaart, Coordinaat _locatie)
        {
            this.locatie = _locatie;
            this.kaart = kaart;
        }

        public void TekenConsole(ConsoleTekener t)
        {
            t.Teken(this);
        }
    }
}