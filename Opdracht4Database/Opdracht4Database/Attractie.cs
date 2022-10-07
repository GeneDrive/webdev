using System.ComponentModel.DataAnnotations;
namespace Database;

public class Attractie
{
    // properties
    public int Id { get; set; }
    public string naam { get; set; }

    protected Attractie() { naam = null!; }
    public Attractie(string _naam)
    {
        naam = _naam;
    }
    public async Task<bool> onderhoudBezig(DatabaseContext c)
    {
        var onderhouden = await Task.Run(() => c.Onderhoud.Where(oh => oh.dateTimeBereik.eind < DateTime.Today).Count());

        if (onderhouden > 0) 
            return true;

        return false;
    }

    public async Task<bool> vrij(DatabaseContext c, DateTimeBereik d)
    {
        var reserv = await Task.Run(() => c.Reserveringen.Single(re => re.dateTimeBereik == d));

        if(reserv == null && await onderhoudBezig(c) == false)
            return true;

        return false;
    }

    public readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);

    // relationships
    public List<Reservering> reserveringen { get; set; }
    public List<Gast> favorieten { get; set; }
    public List<Onderhoud> onderhouds { get; set; }

}