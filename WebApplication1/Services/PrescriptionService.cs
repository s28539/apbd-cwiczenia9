using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.DTO_s;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class PrescriptionService : IPrescritionService

{
    private readonly ApplicationContext _context;

    public PrescriptionService(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> AddPrescription(AddPrescriptionDTO prescriptionDto)
    {
        var patient = await _context.Patients.FindAsync(prescriptionDto.Patient);
        if (patient == null)
        {
            patient = new Patient
            {
                FirstName = prescriptionDto.Patient.FirstName,
                LastName = prescriptionDto.Patient.LastName,
                Birthdate = prescriptionDto.Patient.Birthdate
            };
        }

        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();

        foreach (var medicament in prescriptionDto.Medicaments)
        {
            if (await _context.Medicaments.FindAsync(medicament.IdMedicament) == null)
            {
                return new BadRequestObjectResult("One of medicaments does not exists");
            }
        }

        if (prescriptionDto.Medicaments.Count > 10)
        {
            return new BadRequestObjectResult("You cannot add more than 10 medicaments!");
        }
        var prescription = new Prescription
        {
            Date = prescriptionDto.Date,
            DueDate = prescriptionDto.DueDate,
            IdDoctor = prescriptionDto.IdDoctor,
            IdPatient = patient.IdPatient,
            PrescriptionMedicament = prescriptionDto.Medicaments.Select(medDto => new PrescriptionMedicament()
            {
                IdMedicament = medDto.IdMedicament,
                Dose = medDto.Dose,
                Details = medDto.Details
            }).ToList()
        };

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();

        return new OkObjectResult("Prescription added successfully.");


    }
}