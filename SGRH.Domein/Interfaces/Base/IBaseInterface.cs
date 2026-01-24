

namespace SGRH.Domein.Interfaces.IBaseInterface
{
    public interface IBaseInterface<TModel>  where TModel : class
    {
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(int Id);
        Task CreateAsync(TModel modelo);
        Task DeleteAsync(int Id, int IdUsuario);
        Task UpdateAsync(TModel modelo);

    }
}
