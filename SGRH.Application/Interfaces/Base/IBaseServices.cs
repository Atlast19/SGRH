

using SGRH.Domein.Base;

namespace SGRH.Application.Interfaces.Base
{
    public interface IBaseServices<TModel> where TModel : class
    {
        Task<OperationResult<IEnumerable<TModel>>> GetAllAsync();
        Task<OperationResult<TModel>> GetByIdAsync(int Id);
        Task<OperationResult<TModel>> CreateAsync(TModel modelo);
        Task<OperationResult<TModel>> DeleteAsync(int Id, int IdUsuario);
        Task<OperationResult<TModel>> UpdateAsync(TModel modelo);

    }
}