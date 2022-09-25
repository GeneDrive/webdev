using Authenticatie;
using Xunit;

namespace Authenticatie.Tests;

public class UnitTest1
{
   /////////////////////////////////////////////////////////////
   //
   // Vraag
   //
   //
   // wat word er bedoelt met:
   // Schrijf ook tests waarin je controleert of methoden op de mocks met de juiste parameter zijn aangeroepen.
   //
   //
   //
   //////////////////////////////////////////////////////////////
   [Fact]
   public void GebruikerContext_nieuweGebruikerMetJuisteMailWordGemaakt()
   {
      // arrange
      GebruikerContextMock gebruikerContext = new GebruikerContextMock();
      var mail = "gerda@gmail.com";
      var wachtwoord = "welkom01!";

      // act
      gebruikerContext.NieuweGebruiker(mail, wachtwoord);
      var actualResult = gebruikerContext.GetGebruiker(2);

      // assert
      Assert.Equal(mail, actualResult.Email);
   }

   [Fact]
   public void GebruikerContext_wordUserNietToegevoegdAlsHijAlBestaat()
   {
      // arrange
      GebruikerContextMock gebruikerContext = new GebruikerContextMock();
      bool expectedResult = false;
      bool actualResult = false;

      // act
      gebruikerContext.NieuweGebruiker("hans@hotmail.com", "rgaewrgf");
      gebruikerContext.NieuweGebruiker("hans@hotmail.com", "rgaewrgf");
      actualResult = gebruikerContext.userWasAdded;

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