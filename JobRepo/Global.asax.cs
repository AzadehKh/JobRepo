using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.DynamicData;
using System.Web.Routing;
using JobRepo.Model;
using System.Web;
using System.Web.Profile;
using System.Web.Mvc;
using JobRepo.MVC.Binders;
using JobRepo.MVC;


namespace JobRepo
{
    public class Global : System.Web.HttpApplication
    {


        private static MetaModel s_defaultModel = new MetaModel();
        public static MetaModel DefaultModel
        {
            get
            {
                return s_defaultModel;
            }
        }

        public void Profile_OnMigrateAnonymous(object sender, ProfileMigrateEventArgs args)
        {
            ProfileCommon profile = ProfileCommon.GetProfile();
            ProfileCommon anonymousProfile = ProfileCommon.GetProfile(args.AnonymousID);

            if (  anonymousProfile.RecentSearch.Keywords != null)
                profile.RecentSearch.Keywords = anonymousProfile.RecentSearch.Keywords;

            
            //////// 
            // Delete the anonymous profile. If the anonymous ID is not  
            // needed in the rest of the site, remove the anonymous cookie.

            ProfileManager.DeleteProfile(args.AnonymousID);
            AnonymousIdentificationModule.ClearAnonymousIdentifier();

            // Delete the user row that was created for the anonymous user.
            Membership.DeleteUser(args.AnonymousID, true);


        }

        public static void RegisterRoutes(RouteCollection routes)
        {


            //if we want  JUST those table which [ScaffoldTable] BeginEventHandler accessible/changeable/addale/.. 
            //    via Dynamicdata , this property should be  set “false” 
            //See JobRepoModelExtended.cs to see which tables are accessible via Dynamicdata
            DefaultModel.DynamicDataFolderVirtualPath = "~/Administration/DynamicData/";
            if (DefaultModel.Tables.Count == 0)
                DefaultModel.RegisterContext(typeof(JobRepoDataContext),
                new ContextConfiguration() { ScaffoldAllTables = false });


            //                    IMPORTANT: DATA MODEL REGISTRATION 
            // Uncomment this line to register an ADO.NET Entity Framework model for ASP.NET Dynamic Data.
            // Set ScaffoldAllTables = true only if you are sure that you want all tables in the
            // data model to support a scaffold (i.e. templates) view. To control scaffolding for
            // individual tables, create a partial class for the table and apply the
            // [ScaffoldTable(true)] attribute to the partial class.
            // Note: Make sure that you change "YourDataContextType" to the name of the data context
            // class in your application.
            //DefaultModel.RegisterContext(typeof(YourDataContextType), new ContextConfiguration() { ScaffoldAllTables = false });

            // The following statement supports separate-page mode, where the List, Detail, Insert, and 
            // Update tasks are performed by using separate pages. To enable this mode, uncomment the following 
            // route definition, and comment out the route definitions in the combined-page mode section that follows.
            routes.Add(new DynamicDataRoute("{table}/{action}.aspx")
            {
                Constraints = new RouteValueDictionary(new { action = "List|Details|Edit|Insert" }),
                Model = DefaultModel
            });

			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            
            // The following statements support combined-page mode, where the List, Detail, Insert, and
            // Update tasks are performed by using the same page. To enable this mode, uncomment the
            // following routes and comment out the route definition in the separate-page mode section above.
            //routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx") {
            //    Action = PageAction.List,
            //    ViewName = "ListDetails",
            //    Model = DefaultModel
            //});

            //routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx") {
            //    Action = PageAction.Details,
            //    ViewName = "ListDetails",
            //    Model = DefaultModel
            //});
        }
		       
		private void RegisterModelBinders()
        {
            ModelBinders.Binders.Add(typeof(DateTime), new DateTimeModelBinder());
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters) { filters.Add(new HandleErrorAttribute()); }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            RegisterModelBinders();

            // We are using Injection Dependency rathe than using custom ControllerFactory for 
            // those controllers which have dependency to the other classes and types 
           // ControllerBuilder.Current.SetControllerFactory(new JobRepoControllerFactory());
            Bootstrapper.Initialise();			
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {

        }

        void Session_Start(object sender, EventArgs e)
        {
            //RegisterRoutes(RouteTable.Routes);
        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
