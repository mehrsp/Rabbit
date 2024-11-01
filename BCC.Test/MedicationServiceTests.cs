
namespace BCC.Test;

public class MedicationServiceTests
{

    private readonly IMedicationService _medicationService;

    public MedicationServiceTests()
    {
        var serviceProvider = new ServiceCollection()
            .AddScoped<IMedicationService, MedicationService>()
            .BuildServiceProvider();

        _medicationService = serviceProvider.GetService<IMedicationService>();
    }

    /// <summary>
    /// Validates the quantity_ should throw argument exception_ when quantity is zero or less.
    /// </summary>
    [Fact]
    public void ValidateQuantity_ShouldThrowArgumentException_WhenQuantityIsZeroOrLess()
    {
        int invalidQuantity = 0;

        Action act = () => _medicationService.ValidateQuantity(invalidQuantity);

        act.Should().Throw<ArgumentException>()
           .WithMessage("Quantity must be greater than zero.");
    }

    /// <summary>
    /// Validates the quantity_ should not throw exception_ when quantity is greater than zero.
    /// </summary>
    [Fact]
    public void ValidateQuantity_ShouldNotThrowException_WhenQuantityIsGreaterThanZero()
    {
        int validQuantity = 10;

        Action act = () => _medicationService.ValidateQuantity(validQuantity);

        act.Should().NotThrow();
    }
}
