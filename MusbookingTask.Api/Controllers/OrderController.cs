using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusbookingTask.Application.Orders.Commands.CreateOrder;
using MusbookingTask.Application.Orders.Commands.DeleteOrder;
using MusbookingTask.Application.Orders.Commands.UpdateOrder;
using MusbookingTask.Application.Orders.Queries.GetOrderDetail;
using MusbookingTask.Application.Orders.Queries.GetOrderList;

namespace MusbookingTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult> GetOrders(CancellationToken cancellationToken) => Ok(await _mediator.Send(new GetOrderListQuery(), cancellationToken));        

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(int id, CancellationToken cancellationToken) => Ok(await _mediator.Send(new GetOrderDetailQuery(id), cancellationToken));       

        [HttpPost]
        public async Task<ActionResult> CreateOrder(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            ValidationResult result = new CreateOrderCommandValidator().Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            ValidationResult result = new UpdateOrderCommandValidator().Validate(command);
            if (!result.IsValid)
            {
                return BadRequest(string.Join('\n', result.Errors));
            }

            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id, CancellationToken cancellationToken) =>  Ok(await _mediator.Send(new DeleteOrderCommand(id), cancellationToken));        
    }
}
