using BCC.Application.Contract.APIResult;

namespace BCC.Application.Contract;
public class DeleteMedicationCommand : IRequest<ServiceResult<DeleteMedicationResponse>>
{
    public int Id { get; set; }
}
