using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treefrog.Data;
using Treefrog.Models;
namespace Treefrog.Services;


public class OrderService : IOrderService
{
    private readonly OrderHistoryContext _context;
    private readonly IOrderMappingService _mappingService;
    public Order CurrentOrder { get; set; }

    public OrderService(OrderHistoryContext context, IOrderMappingService mappingService)
    {
        _context = context;
        _mappingService = mappingService;
        _context.Database.EnsureCreated();
    }

    public void SaveOrder(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));

        var dbOrder = _mappingService.ToDbOrder(order);
        _context.Orders.Add(dbOrder);
        _context.SaveChanges();
    }

    public async Task<IEnumerable<Order>> GetOrderHistoryAsync()
    {
        var dbOrders = await _context.Orders.Include(o => o.Items).OrderBy(o => o.OrderNumber).ToListAsync();
        return dbOrders.Select(dbOrder => _mappingService.ToOrder(dbOrder));
    }
}