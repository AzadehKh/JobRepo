using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobRepo.MVC
{
    /*
     This class is obstacle as we are using Injection Dependency rathe than using custom 
     ControllerFactory for those controllers which have dependency to the other classes and types  
    */
    public class JobRepoControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return Activator.CreateInstance(controllerType, new SQLServerKeywordsPopularity()) as IController;
        }
    }
}