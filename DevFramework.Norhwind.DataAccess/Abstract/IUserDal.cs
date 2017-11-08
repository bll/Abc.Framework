using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess;
using DevFramework.Norhwind.Entities.ComplexTypes;
using DevFramework.Norhwind.Entities.Concrete;

namespace DevFramework.Norhwind.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {

        List<UserRoleItem> GetUserRoles(User user);
    }
}
