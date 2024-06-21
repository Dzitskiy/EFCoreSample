using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp2.Entities;

public class Passenger
{
    [Key,Column("ID_psg")]
    public int Id { get; set; }
    
    [Column("name"), MaxLength(20)]
    public string Name { get; set; }
    
    public ICollection<PassInTrip> PassInTrips { get; set; }
}