namespace Authenticatie
{
    class EmailService
    {
        public bool Email(string tekst, string naarAdres)
        {
            bool sentSuccesfully = true;
            System.Console.WriteLine("To: " + naarAdres);
            System.Console.WriteLine(tekst);

            return sentSuccesfully;
        }
    }
}