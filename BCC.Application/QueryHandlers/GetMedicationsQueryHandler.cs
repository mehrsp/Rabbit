
using BCC.Application.Contract.APIResult;

namespace BCC.Application;

public class GetMedicationsQueryHandler : IRequestHandler<GetMedicationsQuery, ServiceResult<List<MedicationViewModel>>>
{
    private readonly IMedicationRepository _medicationRepository;

    public GetMedicationsQueryHandler(IMedicationRepository medicationRepository)
    {
        _medicationRepository = medicationRepository;
    }

    public async Task<ServiceResult<List<MedicationViewModel>>> Handle(GetMedicationsQuery request, CancellationToken cancellationToken)
    {
        var medications = await _medicationRepository.GetAllMedicationAsync();
        if (medications is null || !medications.Any()) 
        {
            return ServiceResult<List<MedicationViewModel>>.NotFound("not found");
        }
        var data= medications.Select(m => new MedicationViewModel
        {
            Id = m.Id,
            Name = m.Name,
            Quantity = m.Quantity,
            CreationDate = m.CreationDate
        }).ToList();

        return ServiceResult<List<MedicationViewModel>>.Success(data);

    }
}
