using Blogy.Business.DTOs.CategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Validators.CategoryValidators
{
    public class CreateCategoryValidator:AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez")
                .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır")
                .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olmalıdır");
        }
    }
}
