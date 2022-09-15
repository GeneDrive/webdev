namespace Authenticatie
{
    public interface IMailservice
    {
        public bool Email(string tekst, string naarAdres, string token);
    }
}