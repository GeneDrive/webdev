using System.ComponentModel.DataAnnotations;
namespace Database;

public class Reservering
{
    // properties
    [Key]
    public int ID { get; set;}
    
    // relationships
    public Gast? gast { get; set;}

    // OWNED
    public DateTimeBereik dateTimeBereik { get; set; }

    public Attractie? attractie { get; set; }
}