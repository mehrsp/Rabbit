

namespace BCC.Infrastructure;

public class MedicationRepository : IMedicationRepository
{
    private readonly MedicationAPIDbContext _context;

    public MedicationRepository(MedicationAPIDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddMedicationAsync(Medication medication)
    {
        _context.Medications.Add(medication);
        await _context.SaveChangesAsync();
        return medication.Id;
    }

    public async Task DeleteMedicationAsync(Medication medication)
    {
        _context.Medications.Update(medication);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Medication>> GetAllMedicationAsync()
    {
        return await _context.Medications.Where(X=>X.IsDeleted==false).ToListAsync();
    }

    public async Task<Medication> GetMedicationAsync(int id)
    {
        return await _context.Medications.SingleAsync(x => x.Id == id);
    }
}

