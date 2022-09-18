namespace Kaart
{
    public class KaartItem : Tekenbaar
    {
        private Coordinaat _locatie
        {
            get
            {
                return _locatie;
            } 
            set
            {
                //if(value.x < 0 || value.y < 0)
                //{
                //    throw new Exception("negatief coordinaat mag niet bestaan");
                //}

// Help
                _locatie = value;
            }
        }
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