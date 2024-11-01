
namespace BCC.Infrastructure;
public class MedicationAPIDbContext : DbContext
{
    public MedicationAPIDbContext(DbContextOptions<MedicationAPIDbContext> options) : base(options) { }

    public DbSet<Medication> Medications { get; set; }
}

