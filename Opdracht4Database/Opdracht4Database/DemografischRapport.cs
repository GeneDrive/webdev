namespace Administratie;
using System;
using Database;

class DemografischRapport : Rapport
{
    private DatabaseContext context;
    public DemografischRapport(DatabaseContext context) => this.context = context;
    public override string Naam() => "Demografie";
    public override async Task<string> Genereer()
    {
        string ret = "Dit is een demografisch rapport: \n";
        ret += $"Er zijn in totaal { await AantalGebruikers() } gebruikers van dit platform (dat zijn gasten en medewerkers)\n";
        var dateTime = new DateTime(2000, 1, 1);
        ret += $"Er zijn { await AantalSinds(dateTime) } bezoekers sinds { dateTime }\n";
        if (await AlleGastenHebbenReservering())
             ret += "Alle gasten hebben een reservering\n";
        else
             ret += "Niet alle gasten hebben een reservering\n";
        ret += $"Het percentage bejaarden is { await PercentageBejaarden() }\n";

        ret += $"De oudste gast heeft een leeftijd van { await HoogsteLeeftijd() } \n";

        ret += "De verdeling van de gasten per dag is als volgt: \n";
        // var dagAantallen = await VerdelingPerDag();
        // var totaal = dagAantallen.Select(t => t.aantal).Max();
        // foreach (var dagAantal in dagAantallen)
        //     ret += $"{ dagAantal.dag }: { new string('#', (int)(dagAantal.aantal / (double)totaal * 20)) }\n";

        // ret += $"{ await FavorietCorrect() } gasten hebben de favoriete attractie inderdaad het vaakst bezocht. \n";

        return ret;
    }
    private async Task<int> AantalGebruikers() => context.Gebruikers.Count<Gebruiker>();
    private async Task<bool> AlleGastenHebbenReservering() => context.Gasten.All((ga) => ga.reserveringen.Count > 0);
    private async Task<int> AantalSinds(DateTime sinds, bool uniek = false) {
        if(uniek)
            return await Task.Run(() => context.Gasten.Where<Gast>(ga => ga.eersteBezoek > sinds).Select(ga => ga.eersteBezoek).Distinct().Count());

        return await Task.Run(() => context.Gasten.Count<Gast>(ga => ga.eersteBezoek > sinds));
    } 
    private async Task<Gast> GastBijEmail(string email)
    {
        int aantalgastenMetMael = await Task.Run(() => context.Gasten.Count<Gast>(ga => ga.email == email));
        if(aantalgastenMetMael != 1)
            return null;

        var gast = await Task.Run(() => context.Gasten.Where<Gast>(ga => ga.email == email));
        return (Gast) gast;
    }
    private async Task<Gast?> GastBijGeboorteDatum(DateTime d)
    {
        int aantalGastMetDate = await Task.Run(() => context.Gasten.Count<Gast>(ga => ga.geboorteDatum == d));
        if(aantalGastMetDate != 1)
            throw new InvalidOperationException("foutje");

        var gast = await Task.Run(() => context.Gasten.Where<Gast>(ga => ga.geboorteDatum == d));
        return (Gast) gast;
    }
    private async Task<double> PercentageBejaarden()
    {
        double alleGastenCount = await Task.Run(() => context.Gasten.Count<Gast>());

        var minimumDatum = DateTime.Today.AddYears(-80);
        double gastenBoven80Count = await Task.Run(() => context.Gasten.Count<Gast>(ga => ga.geboorteDatum <= minimumDatum));
        
        return gastenBoven80Count / alleGastenCount * 100;
    }
    private async Task<int> HoogsteLeeftijd()
    {
        DateTime vandaag = DateTime.Today;
        DateTime hoogsteLeeftijd =  await Task.Run(() => context.Gasten.Min(ga => ga.geboorteDatum));

        int leeftijd = vandaag.Year - hoogsteLeeftijd.Year;

        if(vandaag.DayOfYear < hoogsteLeeftijd.DayOfYear)
            leeftijd--;

        return leeftijd;
    }
    //private async Task<(string dag, int aantal)[]> VerdelingPerDag() => ;
    // private async Task<int> FavorietCorrect() => /* ... */; 
}