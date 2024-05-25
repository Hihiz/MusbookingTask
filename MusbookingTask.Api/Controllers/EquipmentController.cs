using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    }
}
