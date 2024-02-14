
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace test.Models.Repository
{
    public class CompraRepository: InterfaceCompra
    {
        private readonly AplicationDbContext _context;

        public CompraRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Compras>> GetListCompras()
        {
            return await _context.Compras.ToListAsync();
        }
        public async Task<Compras> GetCompras(int id)
        {
            return await _context.Compras.FindAsync(id);
        }

        public async Task DeleteCompra(Compras compras)
        {
             _context.Compras.Remove(compras);
             await _context.SaveChangesAsync();
        }

        public async Task<Compras> AddCompra(Compras compras)
        {
            _context.Add(compras);
            await _context.SaveChangesAsync();
            return compras;
        }

        public async Task UpdateCompra(Compras compras)
        {
            var comprasItem = await _context.Compras.FirstOrDefaultAsync(x => x.Id == compras.Id);
            
            if(comprasItem != null)
            {
                comprasItem.Nombre = compras.Nombre;
                comprasItem.Cantidad = compras.Cantidad;
                comprasItem.Email = compras.Email;
                comprasItem.Phone = compras.Phone;

                await _context.SaveChangesAsync();

            }
           
        }

    }
}
