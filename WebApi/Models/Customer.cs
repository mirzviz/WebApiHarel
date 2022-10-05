using System.ComponentModel.DataAnnotations;

namespace JwtWebApiTutorial.Models;

public class Customer
{
    [Required]
    public int ID { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; } 
    [Required]
    [Phone]
    public string Phone { get; set; } = string.Empty;
}
