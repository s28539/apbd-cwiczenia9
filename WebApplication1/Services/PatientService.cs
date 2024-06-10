using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTO_s;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class PatientService : IPatientService
{
    private readonly ApplicationContext _context;
    
    public PatientService(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<GetPatientWithPrescriptionsDTO> GetPatientData(int PatientID)
    {
        var patient = await _context.Patients
            .Include(p => p.Prescriptions)
            .ThenInclude(prescription => prescription.Doctor)
            .Include(p => p.Prescriptions)
            .ThenInclude(prescription => prescription.PrescriptionMedicament)
            .ThenInclude(pm => pm.Medicament)
            .FirstOrDefaultAsync(p => p.IdPatient == PatientID);
        if (patient == null)
        {
            return null;
        }
        else
        {
            
        }

    }
}