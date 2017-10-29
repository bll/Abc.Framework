using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Norhwind.Business.ValidationRules.FluentValidation;
using DevFramework.Norhwind.Entities.Concrete;
using FluentValidation;
using Ninject.Modules;

namespace DevFramework.Norhwind.Business.DependencyResolves.Ninject
{
    public class ValidationModul : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
        }
    }
}
