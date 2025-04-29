using FluentValidation;
using LibraryDbManager.ReturnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryValidation.ModelValidations.ReturnAndGetModelValidations
{
    public class BookGetModelFluentValidation:AbstractValidator<BookGetModel>
    {
        public BookGetModelFluentValidation()
        {
            RuleFor(r => r.Writer).NotEmpty().WithMessage("نام نویسنده الزامی است");
            RuleFor(r => r.Name).NotEmpty().WithMessage("نام الزامی است");
            RuleFor(r => r.Count).NotEmpty().WithMessage("تعداد کتاب الزامی است").GreaterThan(0);
            RuleFor(r => r.Categories).NotEmpty().WithMessage("حداقل یک دسته بندی اضافه کنید").NotNull().WithMessage("دسته بندی اضافه کنید");
        }
    }
}
