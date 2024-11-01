
namespace BCC.Domains
{
    public class Medication
    {
        private readonly IMedicationService _medicationService;

        public Medication()
        {
            
        }
        public Medication(string name, int quantity,DateTime creationDate,IMedicationService medicationService)
        {
            _medicationService = medicationService;
            ChangeName(name);
            ChangeQuantity(quantity);
            ChangeCreationDate(creationDate);
        }

        private void ChangeName(string name)
        {
            Name = name;
        }
        private void ChangeQuantity(int quantity)
        {
            _medicationService.ValidateQuantity(quantity);
             Quantity = quantity;
        }

        private void ChangeCreationDate(DateTime creationDate)
        {
            CreationDate = creationDate;
        }

        public void DeleteMedican(bool isDeleted)
        {
            if (IsDeleted)
            {
                throw new BusinessValidationException("Medication deleted before");
            }
            IsDeleted = true;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public DateTime CreationDate { get; private set; }
        public bool IsDeleted { get; private set; }
    }
}

