using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Norhwind.DataAccess.Abstract;
using DevFramework.Norhwind.Entities.Concrete;
using DevFramework.Core;
namespace DevFramework.Norhwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {

    }
}
