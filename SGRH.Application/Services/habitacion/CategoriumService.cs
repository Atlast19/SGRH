
using SGRH.Application.DTOs.Habitacion;
using SGRH.Application.Interfaces.habitacion;
using SGRH.Domein.Base;
using SGRH.Domein.Interfaces.Habitaciones;


namespace SGRH.Application.Services.habitacion
{
    public class CategoriumService : ICategoriumService
    {
        private readonly ICategoriumRepository _repository;

        public CategoriumService(ICategoriumRepository repository)
        {
            _repository = repository;
        }

        public Task<OperationResult<CategoriumDTO>> CreateAsync(CategoriumDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<CategoriumDTO>> DeleteAsync(int Id, int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<IEnumerable<CategoriumDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<CategoriumDTO>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<CategoriumDTO>> UpdateAsync(CategoriumDTO modelo)
        {
            throw new NotImplementedException();
        }
    }
}
