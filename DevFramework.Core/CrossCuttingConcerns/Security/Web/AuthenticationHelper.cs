using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace DevFramework.Core.CrossCuttingConcerns.Security.Web
{
    // kullanıcı bilgilerini alıp şifreleyip cookie oluşturan sınıf
    public class AuthenticationHelper
    {
        public static void CreateAuthCookie(Guid id, string userName, string email, DateTime expiration, string[] roles,
            bool rememberMe, string firtName, string lastName)
        {
            var authTicked = new FormsAuthenticationTicket(1, userName, DateTime.Now, expiration, rememberMe,
                CreateAuthTags(email, roles, firtName, lastName, id));

            string encTicket = FormsAuthentication.Encrypt(authTicked);

            // cookie oluşturuyorum
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }


        private static string CreateAuthTags(string email, string[] roles, string firstName, string lastName, Guid id)
        {
            // verileri pipe ile ayırıp yönetiyorum
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(email);
            stringBuilder.Append("|");
            for (int i = 0; i < roles.Length; i++)
            {
                //admin,editor
                stringBuilder.Append(roles[i]);

                if (i < roles.Length - 1)
                {
                    stringBuilder.Append(",");
                }

            }
            stringBuilder.Append("|");
            stringBuilder.Append(firstName);
            stringBuilder.Append("|");
            stringBuilder.Append(lastName);
            stringBuilder.Append("|");
            stringBuilder.Append(id);
            return stringBuilder.ToString();

        }
    }
}
