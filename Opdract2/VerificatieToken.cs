namespace Authenticatie
{
    public class VerificatieToken
    {
        public string token{get;set;}
        public DateTime verloopDatum{get;set;}

        public VerificatieToken(int _verloopDatum = 3, string _token = "sasgsd12345")
        {
            token = _token;
            verloopDatum = DateTime.Today.AddDays(_verloopDatum);
        }
    }
}
