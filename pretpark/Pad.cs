namespace Kaart
{
    public class Pad : Tekenbaar
    {
        private Coordinaat _van; 
        public Coordinaat van 
        { 
            get
            {
                return _van;
            } 
            set
            {
                lengteBerekend = null;
                _van = value;
            } 
        }
        private Coordinaat _naar;
        public Coordinaat naar 
        {  
            get
            {
                return _naar;
            } 
            set
            {
                lengteBerekend = null;
                _naar = value;
            } 
        }
        private float? lengteBerekend;
        public float Lengte()
        {
            if (!lengteBerekend.HasValue)
                lengteBerekend = (float)Math.Sqrt((van.x - naar.x) * (van.x - naar.x) + (van.y - naar.y) * (van.y - naar.y));
            return lengteBerekend.Value;
        }
        public void TekenConsole(ConsoleTekener t)
        {
            for (var i = 0; i < (int)Lengte(); i++)
            {
                var factor = i / Lengte();
                t.SchrijfOp(new Coordinaat((int)Math.Round(van.x + (naar.x - van.x) * factor), (int)Math.Round(van.y + (naar.y - van.y) * factor)), "#");
            }
            t.SchrijfOp(new Coordinaat((int)Math.Round(van.x + (naar.x - van.x) * .5), (int)Math.Round(van.y + (naar.y - van.y) * .5)), (1000 * Lengte()).metSuffixen());
        }
    }
}