using FluentValidation;
using LibraryDbManager.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryValidation.ModelValidations
{
    public class CostumerFluentValidation:AbstractValidator<Costumer>
    {
        public CostumerFluentValidation()
        {
            RuleFor(r => r.FirstName).NotEmpty().WithMessage("نام نمی‌تواند خالی باشد").NotNull().MinimumLength(4).MaximumLength(50);
            RuleFor(r=>r.LastName).NotEmpty().WithMessage("فامیل نمی‌تواند خالی باشد").NotNull().MinimumLength(5).MaximumLength(50);
            RuleFor(r => r.UserName).NotNull().NotEmpty().WithMessage("نام کاربری نمی‌تواند خالی باشد").MinimumLength(5).WithMessage("نام کاربری باید حداقل 5 کاراکتر باشد").MaximumLength(50).WithMessage("نام کاربری نباید بیشتر از 50 کاراکتر باشد");
            RuleFor(r => r.PhoneNumber).NotEmpty().WithMessage("شماره تلفن الزامی است").NotNull().WithMessage("شماره تلفن را وارد کنید").Length(11).WithMessage("طول شماره تلفن باید 11 عدد باشد");
            RuleFor(r => r.PassWord).NotNull().WithMessage(" رمز عبور الزامی است").NotEmpty().WithMessage(" رمز عبور نمیتواند خالی باشد").MinimumLength(8).WithMessage("رمز عبور باید حداقل 8 کاراکتر باشد");
            RuleFor(r => r.NationalCode).NotEmpty().WithMessage(" کدملی الزامی است").NotNull().WithMessage(" کدملی را وارد کنید").Length(10).WithMessage("طول  کدملی باید 10 عدد باشد");        }
    }
}
