using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Treefrog.Models;
using Treefrog.Models.Database;
namespace Treefrog.Services;

public interface IOrderMappingService
{
    DbOrder ToDbOrder(Order order);
    Order ToOrder(DbOrder dbOrder);
}

public class OrderMappingService : IOrderMappingService
{
    public DbOrder ToDbOrder(Order order)
    {
        return new DbOrder
        {
            OrderNumber = order.OrderNumber,
            OrderDate = order.OrderDate,
            CollectionDate = order.CollectionDate,
            Status = order.Status,
            TotalPrice = order.TotalPrice,
            Items = order.Items.Select(item => new DbOrderItem
            {
                ItemName = item.Name,
                Quantity = item.Quantity,
                Price = item.Price
            }).ToList()
        };
    }

    public Order ToOrder(DbOrder dbOrder)
    {
        return new Order
        {
            OrderNumber = dbOrder.OrderNumber,
            OrderDate = dbOrder.OrderDate,
            CollectionDate = dbOrder.CollectionDate,
            Status = dbOrder.Status,
            TotalPrice = dbOrder.TotalPrice,
            Items = dbOrder.Items.Select(item => new Treefrog.Models.MenuItem
            {
                Name = item.ItemName,
                Quantity = item.Quantity,
                Price = item.Price
            }).ToList()
        };
    }
}