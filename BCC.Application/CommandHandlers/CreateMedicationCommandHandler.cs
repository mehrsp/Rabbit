
using BCC.Application.Contract.APIResult;

namespace BCC.Application;

public class CreateMedicationCommandHandler : IRequestHandler<CreateMedicationCommand, ServiceResult<CreateMedicationResponse>>
{
    private readonly IMedicationRepository _medicationRepository;
    private readonly IMedicationService _medicationService;
    public CreateMedicationCommandHandler(IMedicationRepository medicationRepository, IMedicationService medicationService)
    {
        _medicationRepository = medicationRepository;
        _medicationService = medicationService;
    }

    public async Task<ServiceResult<CreateMedicationResponse>> Handle(CreateMedicationCommand request, CancellationToken cancellationToken)
    {
        if(request is null)
        {
            return ServiceResult<CreateMedicationResponse>.BadRequest("request is null");
        }
        var medication = new Medication(request.Name, request.Quantity, DateTime.Now, _medicationService);

        await _medicationRepository.AddMedicationAsync(medication);
 
        var response = new CreateMedicationResponse
        {
            Id = medication.Id
        };
        return ServiceResult<CreateMedicationResponse>.Success(response);
        
    }
}
