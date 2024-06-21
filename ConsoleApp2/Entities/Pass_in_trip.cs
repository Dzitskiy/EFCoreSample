using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp2.Entities;

[Table("Pass_in_trip")]
public class PassInTrip
{
    [Column("trip_no")]
    public int TripNo { get; set; }
    
    [Column("date")]
    public DateTime Date { get; set; }
   
    [Column("ID_psg")]
    public int IdPsg { get; set; }
    
    [Column("place"), MaxLength(10)]
    public string Place { get; set; }
    
    public Passenger Passenger { get; set; }
    
    public Trip Trip { get; set; }
}