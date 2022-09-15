namespace Authenticatie
{
    class GebruikerService
    {
        public IGebruikerContext gebruikerContext = new GebruikerContext();
        public IMailservice emailService = new EmailService();

        public Gebruiker Registreer(string email, string wachtwoord)
        {
            Gebruiker tempUser = gebruikerContext.NieuweGebruiker(wachtwoord, email);

            if(tempUser != null)
            {
                emailService.Email("Deze email is voor uw verificatie. U moet u verifieren voordat u kan inloggen.", tempUser.Email, tempUser.verificatieToken.token);
            }

            return tempUser;
        }

        public bool Login(string email, string wachtwoord)
        {
            bool succes = false;
            for(int i = 0; i < gebruikerContext.AantalGebruikers(); i++)
            {
                Gebruiker tempGebruiker = gebruikerContext.GetGebruiker(i);

                if(tempGebruiker.Email == email)
                {
                    if(tempGebruiker.Wachtwoord == wachtwoord)
                    {
                        if(tempGebruiker.Geverifieerd())
                        {
                            System.Console.WriteLine("Welkom terug " + email);
                            succes = true;
                        }
                        else
                        {
                            System.Console.WriteLine("U moet u eerst nog verifieeren voordat u kan inloggen");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Wachtwoord of email was niet correct ingevoerd!");
                    }
                }
            }

            return succes;
        }

        public bool Verifieer(string email, string token)
        {
            bool succes = false;

            for(int i = 0; i < gebruikerContext.AantalGebruikers(); i++)
            {
                Gebruiker tempGebruiker = gebruikerContext.GetGebruiker(i);

                if(tempGebruiker.Email == email)
                {
                    if(tempGebruiker.verificatieToken.token == token)
                    {
                        if(tempGebruiker.verificatieToken.verloopDatum >= DateTime.Today)
                        {
                            gebruikerContext.GetGebruiker(i).Verifieer();
                            succes = true;
                        }
                        else
                        {
                            System.Console.WriteLine("de token is verlopen!");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Dit token is niet correct");
                    }
                }
            }

            return succes;
        }
    }
}