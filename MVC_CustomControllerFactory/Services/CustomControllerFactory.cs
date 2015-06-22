using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using MVC_CustomControllerFactory.Controllers;

namespace MVC_CustomControllerFactory.Services
{
    public class CustomControllerFactory : IControllerFactory
    {
        private readonly string _controllerNamespace;
        public CustomControllerFactory(string controllerNamespace)
        {
            _controllerNamespace = controllerNamespace;
        }
        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            /*
            //FIRST WAY OF DOING BUT WITH HARDCODED CONTROLLER NAME EACH TIME SAME
            ILoggerService loggerService = new UnityContainer().LoadConfiguration("ola").Resolve<ILoggerService>();
            IController controller = new HomeController(loggerService);
             */


            /**/
            //SECOND WAY OF GENERIC SOLUTION, NO HARD CODED CONTROLLER NAME
            ILoggerService loggerService = new LoggerService();
            Type controllerType = Type.GetType(string.Concat(_controllerNamespace,controllerName, "Controller"));

            IController controller = Activator.CreateInstance(controllerType, new[] {loggerService}) as Controller;
            
            return controller;
        }

        public System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            disposable.Dispose();
        }
    }


            /*
            //THIRD WAY OF GENERIC SOLUTION, NO HARD CODED CONTROLLER NAME

    public class CustomControllerFactory : DefaultControllerFactory
    {        private readonly string _controllerNamespace;
        public CustomControllerFactory(string controllerNamespace)
        {
            _controllerNamespace = controllerNamespace;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            ILoggerService loggerService = new UnityContainer().LoadConfiguration("ola").Resolve<ILoggerService>();
            IController controller = Activator.CreateInstance(controllerType, new[] {loggerService}) as Controller;
            return controller;
            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
             */
}