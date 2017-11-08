using DevFramework.Norhwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DevFramework.Core.Aspects.Postsharp;
using DevFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using DevFramework.Core.Aspects.Postsharp.CacheAspect;
using DevFramework.Core.Aspects.Postsharp.LogAspect;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspect;
using DevFramework.Core.Aspects.Postsharp.TransactionAspect;
using DevFramework.Core.Aspects.Postsharp.ValidationAspect;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Logger;
using DevFramework.Norhwind.Business.ValidationRules.FluentValidation;
using DevFramework.Norhwind.Entities.Concrete;
using DevFramework.Norhwind.DataAccess.Abstract;

namespace DevFramework.Norhwind.Business.Concrate.Managers
{
    //[LogAspect(typeof(FileLogger))] tüm metoları cachleyebiliriz veya properties altındaki assemblyInfo ile tüm klasör içerisndekileri loglayabiliriz.

    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        // [LogAspect(typeof(DatabaseLogger))]
        // [LogAspect(typeof(FileLogger))]
        [PerformanceCounterAspect(10)]
       // [SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);

        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidator))]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            // Business Codes
            _productDal.Update(product2);
        }



    }
}
