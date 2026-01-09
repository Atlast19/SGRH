
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Habitaciones;
using SGRH.Domein.Models.Habitaciones;

namespace SGRH.Application.Services.habitacion
{
    public class CategoriumService : ICategoriumService
    {
        private readonly ICategoriumRepository _repository;

        public CategoriumService(ICategoriumRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult<CategoriumModel>> CreateAsync(CategoriumModel modelo)
        {
            return await _repository.CreateAsync(modelo);
        }

        public async Task<OperationResult<CategoriumModel>> DeleteAsync(int Id, int IdUsuario)
        {
            return await _repository.DeleteAsync(Id, IdUsuario);
        }

        public async Task<OperationResult<IEnumerable<CategoriumModel>>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<OperationResult<CategoriumModel>> GetByIdAsync(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public async Task<OperationResult<CategoriumModel>> UpdateAsync(CategoriumModel modelo)
        {
           return await _repository.UpdateAsync(modelo);
        }
    }
}
