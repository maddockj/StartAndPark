﻿using FluentValidation;
using StartAndPark.Application.ValidationRules;

namespace StartAndPark.Application.Owners.Commands.Create
{
    public class CreateOwnerCommandValidator : AbstractValidator<CreateOwnerCommand>
    {
        public CreateOwnerCommandValidator()
        {
            RuleFor(c => c.Name).OwnerNameRules();
        }
    }
}
