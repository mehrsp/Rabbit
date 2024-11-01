
namespace BCC.Domains
{
    public class MedicationService : IMedicationService
    {
        /// <summary>
        /// Validates that the quantity is greater than zero.
        /// </summary>
        /// <param name="quantity">The quantity to validate.</param>
        public void ValidateQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new BusinessValidationException("Quantity must be greater than zero.");
        }
    }
}


