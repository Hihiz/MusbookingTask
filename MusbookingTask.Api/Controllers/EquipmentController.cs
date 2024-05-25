using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusbookingTask.Application.Equipments.Commands.CreateEquipment;
using MusbookingTask.Application.Equipments.Queries.GetEquipmentList;

namespace MusbookingTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EquipmentController(IMediator mediator) => (_mediator) = (mediator);

        [HttpGet]
        public async Task<ActionResult> GetEquipments(CancellationToken cancellationToken) => Ok(await _mediator.Send(new GetEquipmentListQuery(), cancellationToken));

        [HttpPost]
        public async Task<ActionResult> CreateEquipment(CreateEquipmentCommand command, CancellationToken cancellationToken)
        {
            ValidationResult result = new CreateEquipmentCommandValidator().Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
