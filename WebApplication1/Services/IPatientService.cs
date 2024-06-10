using WebApplication1.DTO_s;

namespace WebApplication1.Services;

public interface IPatientService
{
    Task<GetPatientWithPrescriptionsDTO> GetPatientData(int PatientID);
}