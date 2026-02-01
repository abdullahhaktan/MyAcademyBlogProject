using Blogy.Business.DTOs.BlogDtos;
using FluentValidation;

namespace Blogy.Business.Validators.BlogValidators
{
    public class UpdateBlogValidator : AbstractValidator<UpdateBlogDto>
    {
        public UpdateBlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Başlık boş bırakılamaz");
            RuleFor(x => x.CoverImage).NotEmpty().WithMessage("Kapak resmi boş bırakılamaz");
            RuleFor(x => x.BlogImage1).NotEmpty().WithMessage("Blok resmi 1 bırakılamaz");
            RuleFor(x => x.BlogImage2).NotEmpty().WithMessage("Blok resmi 2 bırakılamaz");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("kategori id bırakılamaz");
        }
    }
}
