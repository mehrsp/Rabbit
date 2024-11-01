
using BCC.Application.Contract.APIResult;

namespace BCC.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class MedicationController : ControllerBase
{
    private readonly IMediator _mediator;

    public MedicationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("Medications")]
    public async Task<ApiResult<List<MedicationViewModel>>> GetMedications([FromQuery]GetMedicationsQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetMedicationsQuery());
        return result.ToApiResult();

      
    }

    [HttpPost]
    public async Task<ApiResult> CreateMedication([FromBody] CreateMedicationCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command);
        return result.ToApiResult();
    }


     [HttpPut]
    public async Task<ApiResult> DeleteMedication(DeleteMedicationCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command);
        return result.ToApiResult();
    }
}

