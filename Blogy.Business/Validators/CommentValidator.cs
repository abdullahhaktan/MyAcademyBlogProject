using Blogy.Entity.Entities;
using FluentValidation;

namespace Blogy.Business.Validators
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı boş olamaz.");
            RuleFor(x => x.BlogId).NotEmpty().WithMessage("Blog boş olamaz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Yorum içeriği boş olamaz.").MaximumLength(250).WithMessage("Yorum içeriği 250 karakterden fazla olamaz");
        }
    }
}
