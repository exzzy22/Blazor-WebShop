using Shared.RequestFeatures;
using System.Collections.Generic;

namespace Service.Implementations;

sealed class OrderService : IOrderService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public OrderService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<PagedList<OrderDto>> GetOrdersAsync(OrderParameters orderParameters) => _mapper.Map<PagedList<OrderDto>>(await _repository.Order.GetOrdersAsync(orderParameters, false));
}
