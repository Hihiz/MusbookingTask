using MediatR;
using MusbookingTask.Application.Dto.Orders;

namespace MusbookingTask.Application.Orders.Queries.GetOrderList
{
    public class GetOrderListQuery : IRequest<List<OrderDto>>
    {

    }
}
