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