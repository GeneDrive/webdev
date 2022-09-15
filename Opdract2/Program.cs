using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticatie
{
    public class main{
        private static GebruikerService _gebruikerService = new GebruikerService(new GebruikerContext(), new EmailService()));
        static void Main(string[] args)
        {
            startLoop(_gebruikerService);
        }

        private static void startLoop(GebruikerService gebruikerService)
        {
            System.Console.WriteLine("Welkom,");
            System.Console.WriteLine("vul de optie in die u wilt kiezen:");
            System.Console.WriteLine("1. inloggen");
            System.Console.WriteLine("2. registreren");
            System.Console.WriteLine("3. verifieer");

            string input = Console.ReadLine();
            checkInput(input, gebruikerService);
        }

        private static void checkInput(string input, GebruikerService gebruikerService)
        {
            ////////////////////////////////////////////////////////////////
            //
            //
            //
            // deze code kan netter, maak een list van methods of zoiets
            //
            //
            //
            ////////////////////////////////////////////////////////////////
            if(input == "1")
            {
                startLogin(gebruikerService);
            } 
            else if(input == "2") 
            {
                startRegistreer(gebruikerService);
            }
            else if (input == "3")
            {
                startVerificatie(gebruikerService);
            }
            else
            {
                System.Console.WriteLine("geen geldige optie gekozen, Probeer het opnieuw.");
                startLoop(gebruikerService);
            }
        }

        private static void startLogin(GebruikerService gebruikerService)
        {
            System.Console.WriteLine("Inloggen");
            System.Console.WriteLine("Voer uw E-mail in:");
            string email = Console.ReadLine();

            System.Console.WriteLine("Voer uw wachtwoord in:");
            string wachtwoord = Console.ReadLine();

            if(gebruikerService.Login(email, wachtwoord))
            {
                System.Console.WriteLine("succesvol ingelogd");
            }
            else
            {
                System.Console.WriteLine("Inloggen gefaald");
                System.Console.WriteLine("probeer het later opnieuw.");

                startLoop(gebruikerService);
            }
        }

        private static void startRegistreer(GebruikerService gebruikerService)
        {
            System.Console.WriteLine("Registratie");
            System.Console.WriteLine("Voer uw E-mail in:");
            string email = Console.ReadLine();

            System.Console.WriteLine("Voer uw wachtwoord in:");
            string wachtwoord = Console.ReadLine();

            if (gebruikerService.Registreer(email, wachtwoord) != null)
            {
                System.Console.WriteLine("succesvol geregistreerd");

                startLoop(gebruikerService);
            }
            else
            {
                System.Console.WriteLine("Registreren gefaald");
                System.Console.WriteLine("probeer het later opnieuw.");

                startLoop(gebruikerService);
            }
        }

        private static void startVerificatie(GebruikerService gebruikerService)
        {
            System.Console.WriteLine("Verificatie");
            System.Console.WriteLine("Voer uw E-mail in:");
            string email = Console.ReadLine();

            System.Console.WriteLine("Voer de opgestuurde code in:");
            string token = Console.ReadLine();

            if (gebruikerService.Verifieer(email, token))
            {
                System.Console.WriteLine("succesvol geverifieert");
                System.Console.WriteLine("U kunt nu inloggen met uw account");

                startLoop(gebruikerService);
            }
            else
            {
                System.Console.WriteLine("Registreren gefaald");
                System.Console.WriteLine("probeer het later opnieuw.");

                startLoop(gebruikerService);
            }
        }
    }
}