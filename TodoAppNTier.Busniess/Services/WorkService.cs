using AutoMapper;
using FluentValidation;
using TodoAppNTier.Busniess.Interfaces;
using TodoAppNTier.Common.ResponseObjects;
using TodoAppNTier.DataAccess.UnitOfWork;
using TodoAppNTier.Dtos.WorkDtos;
using TodoAppNTier.Entities.Concrete;

namespace TodoAppNTier.Busniess.Services
{
    public class WorkService : IWorkServices
    {
        private readonly IUow _wou;
        private readonly IMapper _mapper;
        private readonly IValidator<WorkCreateDto> createValidator; //validator
        private readonly IValidator<WorkUpdateDto> updateValidator;

        public WorkService(IUow wou, IMapper mapper, IValidator<WorkCreateDto> createValidator, IValidator<WorkUpdateDto> updateValidator)
        {
            _wou = wou;
            _mapper = mapper;
            this.createValidator = createValidator;
            this.updateValidator = updateValidator;
        }

        public async Task<IResponse<WorkCreateDto>> Create(WorkCreateDto dto)
        {
            var validator = createValidator.Validate(dto);
            if (validator.IsValid)
            {
                await _wou.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
                await _wou.SavaChange();
                return new Response<WorkCreateDto>(ResponseType.Success, dto);
            }
            else
            {
                List<CustomValidatinoError> errors = new();
                foreach (var err in validator.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = err.ErrorMessage,
                        PropertyName = err.PropertyName
                    });
                }

                return new Response<WorkCreateDto>(ResponseType.ValidationError, dto, errors);
            }
        }

        public async Task<IResponse<List<WorkListDto>>> GetAll()
        {
            var data = _mapper.Map<List<WorkListDto>>(await _wou.GetRepository<Work>().GetAll());
            return new Response<List<WorkListDto>>(ResponseType.Success, data);
        }

        public async Task<IResponse> Remove(object id)
        {
            var removedEntity = await _wou.GetRepository<Work>().GetByFilter(x => x.Id == (int)id);
            if (removedEntity != null)
            {
                _wou.GetRepository<Work>().Remove(removedEntity);
                await _wou.SavaChange();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} Bulunamadı");
        }

        public async Task<IResponse<WorkUpdateDto>> Updated(WorkUpdateDto dto)
        {
            var validator = updateValidator.Validate(dto);
            if (validator.IsValid)
            {
                var updatedEntity = await _wou.GetRepository<Work>().Find(dto.Id);
                if (updatedEntity != null)
                {
                    _wou.GetRepository<Work>().Update(_mapper.Map<Work>(dto), updatedEntity);
                    await _wou.SavaChange();
                    return new Response<WorkUpdateDto>(ResponseType.Success, dto);
                }
                return new Response<WorkUpdateDto>(ResponseType.NotFound, $"{dto.Id} Bulunamadı");
            }
            else
            {
                List<CustomValidatinoError> errors = new();
                foreach (var err in validator.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = err.ErrorMessage,
                        PropertyName = err.PropertyName
                    });
                }
                return new Response<WorkUpdateDto>(ResponseType.ValidationError, dto, errors);
            }
        }

        public async Task<IResponse<IDto>> GetById<IDto>(int id)
        {
            var data = _mapper.Map<IDto>(await _wou.GetRepository<Work>().GetByFilter(x => x.Id == id));
            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} ye ait bir data bulunamadı.");
            }
            return new Response<IDto>(ResponseType.Success, data);
        }

    }
}
