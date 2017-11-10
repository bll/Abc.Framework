using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Utilities.Common;
using DevFramework.Norhwind.Business.Abstract;
using Ninject.Modules;

namespace DevFramework.Norhwind.Business.DependencyResolves.Ninject
{
    // MVC ui katmanında wcf servis ile çalışırken businesmodule yerine servicemodule ile dependency injection çözümlemesi yapacak sınıf
   public class ServiceModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().ToConstant(WcfProxy<IProductService>.CreateChannel());
        }
    }
}
