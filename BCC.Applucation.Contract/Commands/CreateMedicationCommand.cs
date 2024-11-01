using BCC.Application.Contract.APIResult;

namespace BCC.Application.Contract;

public class CreateMedicationCommand : IRequest<ServiceResult<CreateMedicationResponse>>
{
    public string Name { get; set; } 
    public int Quantity { get; set; }
}

