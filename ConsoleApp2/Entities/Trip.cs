using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp2.Entities;

public class Trip
{
    [Key, Column("trip_no")]
    public int TripNo { get; set; }
    
    [Column("ID_comp")]
    public int IdComp { get; set; }
    
    [Column("plane"), MaxLength(10)]
    public string Plane { get; set; }
    
    [Column("town_from"), MaxLength(25)]
    public string TownFrom { get; set; }
    
    [Column("town_to"), MaxLength(25)]
    public string TownTo { get; set; }
    
    [Column("time_out")]
    public DateTime TimeOut { get; set; }
   
    [Column("time_in")]
    public DateTime TimeIn { get; set; }
    
    public Company Company { get; set; }
    
    public ICollection<PassInTrip> PassInTrips { get; set; }
}