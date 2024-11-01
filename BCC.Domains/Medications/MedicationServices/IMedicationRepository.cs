

namespace BCC.Domains;
public interface IMedicationRepository
{
    Task<List<Medication>> GetAllMedicationAsync();
    Task<Medication> GetMedicationAsync(int id);
    Task<int> AddMedicationAsync(Medication medication);
    Task DeleteMedicationAsync(Medication medication);
}
