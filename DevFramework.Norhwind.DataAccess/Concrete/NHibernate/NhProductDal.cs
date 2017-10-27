using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Norhwind.DataAccess.Abstract;
using DevFramework.Norhwind.Entities.ComplexTypes;
using DevFramework.Norhwind.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DevFramework.Norhwind.DataAccess.Concrete
{
    public class NhProductDal : NHEntityRepositoryBase<Product>, IProductDal
    {
        private NHibernateHelper _nHibernateHelper;
        public NhProductDal(NHibernateHelper nHiberniteHelper) : base(nHiberniteHelper)
        {
            _nHibernateHelper = nHiberniteHelper;
        }

    

        public List<ProductDetail> GetProductDetails()
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                             join c in session.Query<Category>() on p.CategoryId equals c.CategoryId
                             select new ProductDetail
                             {
                                 ProductId = p.ProductId,
                                 CategoryName = c.CategoryName,
                                 ProductName = p.ProductName
                             };

                return result.ToList();
            }
        }
    }
}
