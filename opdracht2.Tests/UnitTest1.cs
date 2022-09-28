using Authenticatie;
using Xunit;
using Moq;

namespace Authenticatie.Tests;

public class UnitTest1
{
   [Fact]
   public void GebruikerService_nieuweGebruikerMetJuisteMailWordGemaakt()
   {
      // arrange
      var mail = "gerda@gmail.com";
      var wachtwoord = "welkom01!";
      
      var mock = new Mock<IGebruikerContext>();
      GebruikerService gebruikerService = new GebruikerService(mock.Object, new EmailService());
      mock.Setup(a => a.GetGebruiker(It.IsAny<int>())).Returns(new Gebruiker("man@hotmail.com", "rgaewrgf"));
      mock.Setup(b => b.AantalGebruikers()).Returns(1);
      mock.Setup(c => c.NieuweGebruiker(It.IsAny<string>(), It.IsAny<string>())).Returns(new Gebruiker(mail, wachtwoord));

      // act
      var actualResult = gebruikerService.Registreer(mail, wachtwoord);

      // assert
      Assert.Equal(mail, actualResult.Email);
   }

   [Fact]
   public void GebruikerService_wordnieuweGebruikerAangeroepenAlsHijAlBestaat()
   {
      // arrange
      var mail = "man@hotmail.com";
      var wachtwoord = "rgaewrgf";

      var mock = new Mock<IGebruikerContext>();
      GebruikerService gebruikerService = new GebruikerService(mock.Object, new EmailService());
      mock.Setup(a => a.GetGebruiker(It.IsAny<int>())).Returns(new Gebruiker("man@hotmail.com", "rgaewrgf"));
      mock.Setup(b => b.AantalGebruikers()).Returns(1);
      
      
      IGebruiker expectedResult = null;
      IGebruiker actualResult = null;

      // act
      actualResult = gebruikerService.Registreer(mail, wachtwoord);

      // assert
      Assert.Equal(expectedResult, actualResult);
   }

   [Fact]
   public void GebruikerService_verifieerNietAlsTokenIsVerlopen()
   {
      // arrange
      var mock = new Mock<IGebruikerContext>();
      GebruikerService gebruikerService = new GebruikerService(mock.Object, new EmailService());

      mock.Setup(a => a.GetGebruiker(It.IsAny<int>())).Returns(new Gebruiker("miranda@hotmail.com", "sasgsd12345", -3));
      mock.Setup(b => b.AantalGebruikers()).Returns(1);

      bool expectedResult = false;
      bool actualResult;

      // act
      actualResult = gebruikerService.Verifieer("miranda@hotmail.com", "sasgsd12345");

      // assert
      Assert.Equal(expectedResult, actualResult);
   }
}