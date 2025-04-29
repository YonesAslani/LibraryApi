using FluentValidation;
using LibraryDbManager.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryValidation.ModelValidations
{
    public class CategoryFluentValidation:AbstractValidator<Category>
    {
        public CategoryFluentValidation()
        {
            RuleFor(r => r.Name).NotEmpty().NotNull().MinimumLength(5).MaximumLength(50);
        }
    }
}
