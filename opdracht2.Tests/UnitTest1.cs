using Authenticatie;
using Xunit;

namespace Authenticatie.Tests;

public class UnitTest1
{
   [Fact]
   public void GebruikerService_nieuweGebruikerMetJuisteMailWordGemaakt()
   {
      // arrange
      GebruikerContextMock gebruikerContext = new GebruikerContextMock();
      GebruikerService gebruikerService = new GebruikerService(gebruikerContext, new EmailService());

      var mail = "gerda@gmail.com";
      var wachtwoord = "welkom01!";

      // act
      var actualResult = gebruikerService.Registreer(mail, wachtwoord);

      // assert
      Assert.Equal(mail, actualResult.Email);
   }

   [Fact]
   public void GebruikerService_wordnieuweGebruikerAangeroepenAlsHijAlBestaat()
   {
      // arrange
      GebruikerContextMock gebruikerContext = new GebruikerContextMock();
      GebruikerService gebruikerService = new GebruikerService(gebruikerContext, new EmailService());
      
      var mail = "man@hotmail.com";
      var wachtwoord = "rgaewrgf";
      Gebruiker expectedResult = null;
      Gebruiker actualResult = null;

      // act
      actualResult = gebruikerService.Registreer(mail, wachtwoord);

      // assert
      Assert.Equal(expectedResult, actualResult);
   }

   [Fact]
   public void GebruikerService_verifieerNietAlsTokenIsVerlopen()
   {
      // arrange
      GebruikerContextMock gebruikerContext = new GebruikerContextMock();
      GebruikerService gebruikerService = new GebruikerService(gebruikerContext, new EmailService());
      bool expectedResult = false;
      bool actualResult;

      // act
      gebruikerService.Registreer("miranda@hotmail.com" , "egfiwygfeiwyagfwiyfrgiwqyegfiwyegfiy");
      actualResult = gebruikerService.Verifieer("miranda@hotmail.com", "sasgsd12345");

      // assert
      Assert.Equal(expectedResult, actualResult);
   }
}