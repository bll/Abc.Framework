using DevFramework.Norhwind.Entities.Concrete;
using FluentValidation;

namespace DevFramework.Norhwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.ProductName).Length(2, 20);
            RuleFor(p => p.UnitPrice).GreaterThan(20).When(p => p.CategoryId == 1);
          //RuleFor(p => p.ProductName).Must(StartWithA);// custom productName A ile başlıyorsa
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
