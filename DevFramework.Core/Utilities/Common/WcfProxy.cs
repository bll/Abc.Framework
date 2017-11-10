using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DevFramework.Core.Utilities.Common
{
    //MVC katmanından wcf projemizi çekecek WcfProxy Channel Factory
    public class WcfProxy<T>
    {
        public static T CreateChannel()
        {
            //http://localhost:60124/ProductService.svc
            string baseAddress = WebConfigurationManager.AppSettings["ServiceAddress"];
            string address = string.Format(baseAddress, typeof(T).Name.Substring(1)); //örn IProductService 0. karakterden sonrasını al

            var binding = new BasicHttpBinding();
            var channel= new ChannelFactory<T>(binding,address);

            return channel.CreateChannel();

        }
    }
}
