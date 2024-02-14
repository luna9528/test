namespace test.Models.Repository
{
    public interface InterfaceCompra
    {
        Task<List<Compras>> GetListCompras();
        Task<Compras> GetCompras(int id);
        Task DeleteCompra(Compras compras);
        Task<Compras> AddCompra(Compras compras);
        Task UpdateCompra(Compras compras);
    }
}
