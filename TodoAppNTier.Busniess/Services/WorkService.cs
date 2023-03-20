using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.Busniess.Interfaces;
using TodoAppNTier.DataAccess.UnitOfWork;
using TodoAppNTier.Dtos.WorkDtos;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.Busniess.Services
{
    public class WorkService : IWorkServices
    {
        private readonly IUow _wou;

        public WorkService(IUow wou)
        {
            _wou = wou;
        }

        public async Task Create(WorkCreateDto dto)
        {
            await _wou.GetRepository<Work>().Create(new()
            {
                Definition = dto.Definition,
                IsCompleted = dto.IsCompleted,
            });
            await _wou.SavaChange();
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            var list = await _wou.GetRepository<Work>().GetAll();

            var workList = new List<WorkListDto>();

            if (list != null && list.Count > 0)
            {
                foreach (var work in list)
                {
                    workList.Add(new()
                    {
                        Definition = work.Definition,
                        Id = work.Id,
                        IsCompleted = work.IsCompleted
                    });
                }

                return   workList;

            }
            return null;
        }

        public async Task<WorkListDto> GetById(object id)
        {
            var work = await _wou.GetRepository<Work>().GetByFilter(x=>x.Id == (int)id);

            return new()
            {
                IsCompleted = work.IsCompleted,
                Definition = work.Definition,
            };
        }

        public async Task Remove(object id)
        {
            var deleted = await _wou.GetRepository<Work>().GetById(id);
            _wou.GetRepository<Work>().Remove(deleted);
            await _wou.SavaChange();
        }

        public async Task Updated(WorkUpdateDto dto)
        {
            _wou.GetRepository<Work>().Update(new()
            {
                Definition = dto.Definition,
                Id = dto.Id,
                IsCompleted = dto.IsCompleted,
            });
            await _wou.SavaChange();
        }
    }
}
