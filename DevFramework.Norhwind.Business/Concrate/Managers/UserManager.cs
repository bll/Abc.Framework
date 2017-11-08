﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Norhwind.Business.Abstract;
using DevFramework.Norhwind.DataAccess.Abstract;
using DevFramework.Norhwind.Entities.ComplexTypes;
using DevFramework.Norhwind.Entities.Concrete;

namespace DevFramework.Norhwind.Business.Concrate.Managers
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetByUserNameAndPassword(string userName, string password)
        {
            return _userDal.Get(u => u.UserName == userName & u.Password == password);
        }

        public List<UserRoleItem> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user);
        }
    }
}
