using TodoAppNTier.Common.ResponseObjects;
using TodoAppNTier.Dtos.WorkDtos;

namespace TodoAppNTier.Busniess.Interfaces
{
    public interface IWorkServices
    {
        Task<IResponse<List<WorkListDto>>> GetAll();

        Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto);

        Task<IResponse<IDto>> GetById<IDto>(int id);
        
        Task<IResponse> Remove(object id);
        
        Task<IResponse<WorkUpdateDto>> Updated(WorkUpdateDto dto);
    }
}
