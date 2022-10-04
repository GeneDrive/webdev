using System.ComponentModel.DataAnnotations;
namespace Database;

//[Owned]
public class DateTimeBereik
{
    // properties
    public DateTime Begin { get; set; }
    public DateTime? Eind { get; set; }
    public bool Eindigt()
    {
        Eind = DateTime.Now;

        return true;
    }

    public bool Overlapt(DateTimeBereik that)
    {   
        ///////////////////////
        //
        //// Logica hier
        //
        ////////////////////////
        // if(this == that)
        // {
        //     return true;
        // }
        // else
        // {
        //     return false;
        // }

        // Temp
        return true;
    }
}