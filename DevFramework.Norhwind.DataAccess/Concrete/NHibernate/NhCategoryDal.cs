using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Norhwind.DataAccess.Abstract;
using DevFramework.Norhwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Norhwind.DataAccess.Concrete
{
    public class NhCategoryDal : NHEntityRepositoryBase<Category>, ICategoryDal
    {
        public NhCategoryDal(NHibernateHelper nHiberniteHelper) : base(nHiberniteHelper)
        {
        }
    }
}
