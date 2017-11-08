using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime.Tree;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Norhwind.DataAccess.Abstract;
using DevFramework.Norhwind.Entities.ComplexTypes;
using DevFramework.Norhwind.Entities.Concrete;

namespace DevFramework.Norhwind.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        //kullanıcıya göre kullanıcı rollerini getiren complex type
        public List<UserRoleItem> GetUserRoles(User user)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from ur in context.UserRoles
                    join r in context.Roles
                        on ur.RoleId equals r.Id
                    where ur.UserId == user.Id
                    select new UserRoleItem
                    {
                        RoleName = r.Name
                    };

                return result.ToList();
            }
        }
    }
}
