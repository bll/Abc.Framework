using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using DevFramework.Norhwind.Business.Abstract;
using DevFramework.Norhwind.Business.DependencyResolves.Ninject;
using DevFramework.Norhwind.Entities.Concrete;

namespace DevFramework.Northwind.WebApi.MessageHandlers
{
    // yapılacak her isteğin önünde bu token servisi çalışacak.
    public class AuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault();
                if (token != null)
                {
                    byte[] data = Convert.FromBase64String(token);
                    string decodedString = Encoding.UTF8.GetString(data);
                    string[] tokenValues = decodedString.Split(':');

                    //DelegatingHandler içinde IUserService erişebilmek için Factory Design Pattern yapısını kullanarak
                    // bir InstanceFactory sınıfı tanımlayıp vereceğimiz nesne için bir instance oluşturuyoru bu nesnenin karşılığı BusinessModule da var
                    // ve InstanceFactory sınıfında bunu çözümledim.

                    IUserService userService = InstanceFactory.GetInstance<IUserService>();


                    // api isteğinden gelen token içindei kullanıcı adı ve şifre ile kullanıcı ve rollerin kontrolü

                    User user = userService.GetByUserNameAndPassword(tokenValues[0], tokenValues[1]);
                    if (user != null)
                    {
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(tokenValues[0]), userService.GetUserRoles(user).Select(u=>u.RoleName).ToArray()); // kullanıcı rol kontrolü
                        Thread.CurrentPrincipal = principal; //backend için
                        HttpContext.Current.User = principal; // web api için
                    }
                }
            }

            catch
            {

            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}