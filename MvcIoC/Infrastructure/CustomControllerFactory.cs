﻿using MvcIoC.Controllers;
using MvcIoC.Models;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace MvcIoC.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName.ToLower().StartsWith("proteintracker"))
            {
                var service = new ProteinTrackingService(new ProteinRepository());
                var controller = new ProteinTrackerController(service);

                return controller;
            }

            var defaultFactory = new DefaultControllerFactory();
            return defaultFactory.CreateController(requestContext, controllerName);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;

            if (disposable != null)
                disposable.Dispose();
        }
    }
}