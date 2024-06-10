using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.DTO_s;

public class AddPrescriptionDTO
{
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    public Patient Patient { get; set; }
    
}