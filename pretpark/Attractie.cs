namespace Kaart
{
    class Attractie : KaartItem
    {
        private Coordinaat _locatie{get; set;}
        private Kaart kaart;
        private char Karakter{get;}
        private int? _minimaleLengte{get; set;}
        private int _angstLevel{get; set;}
        private string _naam{get; set;}

        public Attractie(Kaart kaart, Coordinaat _locatie, string naam) : base(kaart, _locatie)
        {
          
        }
    }
}