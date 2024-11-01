
using BCC.Application.Contract.APIResult;

namespace BCC.Application;

public class DeleteMedicationCommandHandler : IRequestHandler<DeleteMedicationCommand, ServiceResult<DeleteMedicationResponse>>
{
    private readonly IMedicationRepository _repository;

    public DeleteMedicationCommandHandler(IMedicationRepository repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResult<DeleteMedicationResponse>> Handle(DeleteMedicationCommand request, CancellationToken cancellationToken)
    {
        var medication = await _repository.GetMedicationAsync(request.Id);
        medication.DeleteMedican(medication.IsDeleted);
        await _repository.DeleteMedicationAsync(medication);
        return ServiceResult<DeleteMedicationResponse>.Success();
      
    }
}