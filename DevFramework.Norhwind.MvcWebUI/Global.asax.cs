﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using DevFramework.Core.Utilities.MVC.Infrastructure;
using DevFramework.Norhwind.Business.DependencyResolves.Ninject;

namespace DevFramework.Norhwind.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //mvc ui katmanı istediğimizde dll istediğmizde de service üzerinden çalışır
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule(), new AutoMapperModule()));
            // ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new ServiceModule(), new AutoMapperModule()));


        }

        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {
                    return;
                }

                var encTicket = authCookie.Value;
                if (String.IsNullOrEmpty(encTicket))
                {
                    return;
                }

                var ticket = FormsAuthentication.Decrypt(encTicket);
                // core katmanında oluşturduğumuz SecurityUtilities ile yeni identiy ticket oluşturuyoruz. 

                var securityUtlities = new SecurityUtilities();
                var identity = securityUtlities.FormsAuthTicketToIdentity(ticket);
                var principal = new GenericPrincipal(identity, identity.Roles);

                HttpContext.Current.User = principal; // mvc katmanı için
                Thread.CurrentPrincipal = principal; //backend de kullanabilmek için
            }
            catch (Exception)
            {

            }
        }

    }
}
