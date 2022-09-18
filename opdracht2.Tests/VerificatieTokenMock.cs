using Authenticatie;

namespace Authenticatie
{
    public class VerificatieTokenMock : IVerificatieToken
    {
        public string token{get;set;} = "sasgsd12345";
        public DateTime verloopDatum{get;set;} = DateTime.Today.AddDays(-1);
    }
}