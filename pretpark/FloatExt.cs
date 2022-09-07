namespace Kaart
{
    public static class ExtensionMethods
    {
        public static string metSuffixen(this float value)
        {
            string ReturnValue = "";
            if(value >= 1000f && value < 1000000f && value < 1000000000f) 
            {
                ReturnValue = Math.Round(value / 1000, 1) + "K";
            } 
            else if(value >= 1000000f && value < 1000000000f) 
            {
                ReturnValue = Math.Round(value / 1000000, 1) + "M";
            }
            else if(value >= 1000000000f) 
            {
                ReturnValue = Math.Round(value / 1000000000, 1) + "B";
            }

            return ReturnValue;
        }
    }
}
