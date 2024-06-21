using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp2.Entities;

public class Company
{
    [Key,Column("ID_comp")]
    public int Id { get; set; }
    
    [Column("name"), MaxLength(10)]
    public string Name { get; set; }
    
    public ICollection<Trip> Trips { get; set; }
}