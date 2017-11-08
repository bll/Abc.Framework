using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using DevFramework.Norhwind.Business.Abstract;

namespace DevFramework.Norhwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Account
        public string Login(string userName, string password)
        {
            var user = _userService.GetByUserNameAndPassword(userName, password);

            if (user != null)
            {
                AuthenticationHelper.CreateAuthCookie(
                    new Guid(), user.UserName,
                    user.Email,
                    DateTime.Now.AddDays(15),
                    _userService.GetUserRoles(user).Select(u => u.RoleName).ToArray(), //roller array beklediği için convert ettim
                   // new[] { "Student" },
                    false,
                    user.FirstName,
                    user.LastName);
                return "User is authenticated!";

            }

            return "User is Not authenticated.";

        }
    }
}