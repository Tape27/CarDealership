using CarDealership.Domain.Abstractions;
using CarDealership.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CarDealershipDbContext _context;
        public OrderRepository(CarDealershipDbContext context)
        {
            _context = context;
        }

        public async Task SetCompleted(int id)
        {
            await _context.Orders.Where(x => x.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(x => x.Checked, true));
        }
        public async Task<int> Create(OrderModel order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }

        public async Task<IEnumerable<OrderModel>> GetAll() =>
            await _context.Orders.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<OrderModel?>> GetUnchecked() =>
            await _context.Orders.AsNoTracking()
                .Where(x => x.Checked == false)
                .ToListAsync();

        public async Task<int> GetCountUnchecked() =>
            await _context.Orders.AsNoTracking()
                .Where(x => x.Checked == false)
                .CountAsync();
    }
}
