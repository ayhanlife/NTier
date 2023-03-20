using TodoAppNTier.Dtos.WorkDtos;

namespace TodoAppNTier.Busniess.Interfaces
{
    public interface IWorkServices
    {
        Task<List<WorkListDto>> GetAll();
        Task Create(WorkCreateDto dto);
        Task<WorkListDto> GetById(object id);
        Task Remove(object id);
        Task Updated(WorkUpdateDto dto);
    }
}
