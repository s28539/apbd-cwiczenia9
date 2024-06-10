using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO_s;

public class AddMedicamentDTO
{
    [Required]
    public int IdMedicament { get; set; }
    
    public int? Dose { get; set; }

    [MaxLength(100)]
    public string Details { get; set; }
}