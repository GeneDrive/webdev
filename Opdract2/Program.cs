using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticatie
{
    public class main{
        GebruikerService gebruikerService = new GebruikerService();
        static void Main(string[] args)
        {
            startLoop();
        }

        private static void startLoop()
        {
            System.Console.WriteLine("Welkom,");
            System.Console.WriteLine("vul de optie in die u wilt kiezen:");
            System.Console.WriteLine("1. inloggen");
            System.Console.WriteLine("2. registreren");
            System.Console.WriteLine("3. verifieer");

            string input = Console.ReadLine();
            System.Console.WriteLine(input);
        }

        void checkInput(string input)
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
                startLogin();
            } 
            else if(input == "2") 
            {
                startRegistreer();
            }
            else if (input == "3")
            {
                startVerificatie();
            }
            else
            {
                System.Console.WriteLine("geen geldige optie gekozen, Probeer het opnieuw.");
                startLoop();
            }
        }

        void startLogin()
        {
            System.Console.WriteLine("Inloggen");
            System.Console.WriteLine("Voer uw E-mail in:");
            string mail = Console.ReadLine();

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

                startLoop();
            }
        }

        void startRegistreer()
        {
            System.Console.WriteLine("Inloggen");
            System.Console.WriteLine("Voer uw E-mail in:");
            string mail = Console.ReadLine();

            System.Console.WriteLine("Voer uw wachtwoord in:");
            string wachtwoord = Console.ReadLine();

            if (gebruikerService.Registreer(email, wachtwoord) != null)
            {
                System.Console.WriteLine("succesvol geregistreerd");

                ////////////////////////////////////////////////////////////////
                //
                //
                //
                // stuur verificatie email
                // doe de check anders
                //
                //
                //
                ////////////////////////////////////////////////////////////////

                startLoop();
            }
            else
            {
                System.Console.WriteLine("Registreren gefaald");
                System.Console.WriteLine("probeer het later opnieuw.");

                startLoop();
            }
        }

        void startVerificatie()
        {
            System.Console.WriteLine("Verificatie");
            System.Console.WriteLine("Voer uw E-mail in:");
            string mail = Console.ReadLine();

            System.Console.WriteLine("Voer de opgestuurde code in:");
            string token = Console.ReadLine();

            if (gebruikerService.Verifieer(email, token))
            {
                System.Console.WriteLine("succesvol geverifieert");
                System.Console.WriteLine("U kunt nu inloggen met uw account");

                startLoop();
            }
            else
            {
                System.Console.WriteLine("Registreren gefaald");
                System.Console.WriteLine("probeer het later opnieuw.");

                startLoop();
            }
        }
    }
}