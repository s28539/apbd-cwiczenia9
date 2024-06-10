using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO_s;

namespace WebApplication1.Services;

public interface IPrescritionService
{
   Task<IActionResult> AddPrescription(AddPrescriptionDTO prescriptionDto);
}
