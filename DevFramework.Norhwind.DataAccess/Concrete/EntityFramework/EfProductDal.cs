﻿using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Norhwind.DataAccess.Abstract;
using DevFramework.Norhwind.Entities.ComplexTypes;
using DevFramework.Norhwind.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;


namespace DevFramework.Norhwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetail> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.CategoryId equals c.CategoryId
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
