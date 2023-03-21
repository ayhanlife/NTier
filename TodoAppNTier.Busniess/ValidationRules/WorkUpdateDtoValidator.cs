using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.Dtos.WorkDtos;

namespace TodoAppNTier.Busniess.ValidationRules
{
    public class WorkUpdateDtoValidator : AbstractValidator<WorkUpdateDto>
    {
        public WorkUpdateDtoValidator()
        {
            this.RuleFor(x => x.Definition).NotEmpty();
            this.RuleFor(x => x.Id).NotEmpty();


        }

    }
}
