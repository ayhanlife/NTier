﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.Dtos.WorkDtos;

namespace TodoAppNTier.Busniess.ValidationRules
{
    public class WorkCreateDtoValidator: AbstractValidator<WorkCreateDto>
    {
        public WorkCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Definition is required");
        }
    }
}
