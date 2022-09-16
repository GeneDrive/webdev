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
   public void Test1()
   {
      // arrange

      // act

      // assert
   }

   [Fact]
   public void Test1()
   {
      // arrange

      // act

      // assert
   }
}