using Authenticatie;
using Xunit;

namespace Authenticatie.Tests;

public class UnitTest1
{
   [Fact]
   public void GebruikerContext_wordElkeGebruikerGecheckedOfZeAllBestaam()
   {
      // arrange
      GebruikerContextMock gebruikerContext = new GebruikerContextMock();
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
      bool actualResult;

      // act
      gebruikerContext.NieuweGebruiker("man@hotmail.com", "rgaewrgf");
      actualResult = gebruikerContext.userWasAdded;

      // assert
      Assert.Equal(expectedResult, actualResult);
   }

   [Fact]
   public void Test1()
   {
      // arrange

      // act

      // assert
   }
}