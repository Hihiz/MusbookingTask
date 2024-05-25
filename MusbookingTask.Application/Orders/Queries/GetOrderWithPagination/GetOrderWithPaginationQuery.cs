using MediatR;
using MusbookingTask.Application.Dto.Orders;

namespace MusbookingTask.Application.Orders.Queries.GetOrderWithPagination
{
    public class GetOrderWithPaginationQuery : IRequest<List<OrderDto>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetOrderWithPaginationQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
