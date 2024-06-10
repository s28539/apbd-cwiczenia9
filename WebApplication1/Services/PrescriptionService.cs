using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.DTO_s;

namespace WebApplication1.Services;

public class PrescriptionService : IPrescritionService

{
    private readonly ApplicationContext _context;

    public PrescriptionService(ApplicationContext context)
    {
        _context = context;
    }
    public Task<IActionResult> AddPrescription(AddPrescriptionDTO prescriptionDto)
    {
        var patient = await _context.Patients.FindAsync(prescriptionDto)
    }
}