using FluentValidation;
using LibraryDbManager.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryValidation.ModelValidations
{
    public class AdminFluentValidation:AbstractValidator<Admin>
    {
        public AdminFluentValidation()
        {
            RuleFor(r => r.FirstName).NotEmpty().WithMessage("نام نمی‌تواند خالی باشد").MaximumLength(50).MinimumLength(3).WithMessage("طول نام باید بیشتر از 3 کاراکتر باشد");
            RuleFor(r=>r.LastName).NotEmpty().WithMessage("فامیل نمی‌تواند خالی باشد").MaximumLength(50).MinimumLength(5);
            RuleFor(r => r.AdminTypeId).NotNull().WithMessage("نوع ادمین را مشخص کنید");
            RuleFor(r => r.NationalCode).NotEmpty().WithMessage("لطفا کد ملی را وارد کنید").Length(10).WithMessage("طول کد ملی نا معتبر است");
        }
    }
}
