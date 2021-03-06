﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Norhwind.Business.Abstract;
using DevFramework.Norhwind.Business.Concrate.Managers;
using DevFramework.Norhwind.DataAccess.Abstract;
using DevFramework.Norhwind.DataAccess.Concrete;
using DevFramework.Norhwind.DataAccess.Concrete.EntityFramework;
using DevFramework.Norhwind.DataAccess.Concrete.NHibernate.Helpers;
using Ninject.Modules;

namespace DevFramework.Norhwind.Business.DependencyResolves.Ninject
{
    public class BusinessModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>();
            Bind<IUserDal>().To<EfUserDal>();


            Bind(typeof(IQueryableRepository<>)).To((typeof(EfQueryableRepository<>)));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();



        }
    }
}
