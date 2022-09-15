namespace Authenticatie
{
    public class EmailService : IMailservice
    {
        public bool Email(string tekst, string naarAdres, string token)
        {
            bool sentSuccesfully = true;
            System.Console.WriteLine("To: " + naarAdres);
            System.Console.WriteLine(tekst);
            System.Console.WriteLine("hier is uw verificatie token: " + token);

            return sentSuccesfully;
        }
    }
}