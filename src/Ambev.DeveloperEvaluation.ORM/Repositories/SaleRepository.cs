using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Sale?> GetByIdAsync(Guid id)
            => await _context.Sales
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == id);

        public async Task<List<Sale>> GetAllAsync()
            => await _context.Sales.Include(s => s.Items).ToListAsync();

        public async Task AddAsync(Sale sale)
            => await _context.Sales.AddAsync(sale);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
        public void Delete(Sale sale)
        {
            _context.Sales.Remove(sale);
        }
    }
}
