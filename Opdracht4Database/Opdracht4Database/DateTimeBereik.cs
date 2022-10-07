using System.ComponentModel.DataAnnotations;
namespace Database;

//[Owned]
public class DateTimeBereik
{
    // properties
    public DateTime begin { get; set; }
    public DateTime? eind { get; set; }
    public bool Eindigt()
    {
        eind = DateTime.Now;

        return true;
    }

    public bool overlapt(DateTimeBereik that)
    {   
        if(this.begin >= that.begin && this.begin <= that.eind)
        {
            return true;
        }
        else if(this.eind >= that.begin && this.eind <= that.eind)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}