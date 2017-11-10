using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Norhwind.Business.DependencyResolves.Ninject
{
    //Web Api AuthenticationHandler sınıfına IUserDal gibi nesneleri için istance üreten fabrika
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModule(),new AutoMapperModule());
            return kernel.Get<T>();
        }
    }
}
