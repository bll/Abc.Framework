using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

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

                    if (tokenValues[0] == "bilal" && tokenValues[1] == "demo")
                    {
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(tokenValues[0]), new[] { "Admin" });
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