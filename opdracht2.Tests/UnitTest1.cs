using Authenticatie;
using Xunit;
using Moq;

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
   public void GebruikerContext_wordElkeGebruikerGecheckedOfZeAllBestaam()
   {
      // arrange
      Mock<IGebruikerContext> gebruikerContext = new M;
      int expectedResult = gebruikerContext.AantalGebruikers();
      int actualResult = 0;

      // act
      gebruikerContext.NieuweGebruiker("martijn@hotmail.com", "massfgweaefg");
      actualResult = gebruikerContext.aantalLoops;
      
      // assert
      Assert.Equal(expectedResult, actualResult);
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