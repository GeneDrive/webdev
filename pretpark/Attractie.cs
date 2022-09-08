namespace Kaart
{
    public class Attractie : KaartItem
    {
        private Coordinaat _locatie{get; set;}
        private Kaart kaart;
        private char Karakter{get;}
        private int? _minimaleLengte{get; set;}
        private int _angstLevel{get; set;}
        private string _naam{get; set;}

        public Attractie(Kaart kaart, Coordinaat _locatie, string naam)
        {
            this._locatie = _locatie;
            this.kaart = kaart;
            this._naam = naam;
        }

        public void TekenConsole(ConsoleTekener t)
        {
            System.Console.WriteLine(Karakter);
        }
    }
}