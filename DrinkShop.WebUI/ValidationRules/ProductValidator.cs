using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkShopCore.Entities;
using FluentValidation;

namespace DrinkShop.WebUI.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotNull().WithMessage("{PropertyName} can not be Null")
                .NotEmpty().WithMessage("{PropertyName} can not be Empty");
            RuleFor(x => x.Image).NotNull().WithMessage("Image can not be Null")
                .NotEmpty().WithMessage("{PropertyName} can not be Empty");
            RuleFor(x => x.SubCategoryId).NotNull().WithMessage("{PropertyName} can not be Null")
                .NotEmpty().WithMessage("{PropertyName} can not be Empty");
            RuleFor(x => x.CategoryId).NotNull().WithMessage("{PropertyName} can not be Null")
                .NotEmpty().WithMessage("{PropertyName} can not be Empty");
            RuleFor(x => x.UnitInStock).NotNull().WithMessage("{PropertyName} can not be Null")
                .NotEmpty().WithMessage("{PropertyName} can not be Empty")
                .GreaterThan(32).WithMessage("Inadequate unit of products!");
            RuleFor(x => x.UnitPrice).NotNull().WithMessage("{PropertyName} can not be Null")
                .NotEmpty().WithMessage("{PropertyName} can not be Empty");
        }

        protected bool BeAValidName(string name)
        {
            name.Replace(" ", "");
            name.Replace("-", "");
            name.Replace("=", "");
            return name.All(Char.IsLetter);
        }
    }
}
