using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;

namespace WebApplication1.Models;

[Table("Prescription")]
public class Prescription
{
    [Key] public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public ICollection<PrescriptionMedicament> PrescriptionMedicament { get; set; } = new HashSet<PrescriptionMedicament>();
}