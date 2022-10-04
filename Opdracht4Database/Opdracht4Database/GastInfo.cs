using System.ComponentModel.DataAnnotations;
namespace Database;

public class GastInfo
{
    // properties
    [Key]
    public int ID { get; set;}

    public string LaatstBezochteURL { get; set; }

    // relationships
    // OWNED
    public Coordinaat coordinaat { get; set; }
    public Gast gast { get; set; }
}