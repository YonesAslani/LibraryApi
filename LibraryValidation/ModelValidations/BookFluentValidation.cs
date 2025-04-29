using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LibraryDbManager.DbModels;

namespace LibraryValidation.ModelValidations
{
    public class BookFluentValidation:AbstractValidator<Book>
    {
        public BookFluentValidation()
        {
            RuleFor(r => r.BookName).NotEmpty().MaximumLength(50).MinimumLength(5).NotNull();
            RuleFor(r => r.BookCount).NotEmpty().NotNull().InclusiveBetween(1, 20);
            RuleFor(r => r.BookWriter).NotEmpty().NotNull();
        }
    }
}
