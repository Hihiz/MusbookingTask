using MediatR;
using MusbookingTask.Application.Dto.Orders;

namespace MusbookingTask.Application.Orders.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery : IRequest<OrderDto>
    {
        public int Id { get; set; }

        public GetOrderDetailQuery(int id) => (Id) = (id);
    }
}
