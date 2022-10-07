using System.ComponentModel.DataAnnotations;
namespace Database;

public class GastInfo
{
    // properties
    public int Id { get; set;}

    public string LaatstBezochteURL { get; set; }

    // relationships
    // OWNED
    public Coordinaat coordinaat { get; set; }
    public int gastForeignKey { get; set; }
    public Gast gast { get; set; }
}