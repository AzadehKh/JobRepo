    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace JobRepo
{
    public class UserNameTextbox : TextBox, IScriptControl
    {

        private ScriptManager sMgr;
        
        
        public string minLen;
        public string validating;
        public string validated; 

        public IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            ScriptControlDescriptor descriptor =
                new ScriptControlDescriptor("JobRepo.UserNameTextbox", this.ClientID);

            descriptor.AddProperty("minLen", minLen);

            descriptor.AddEvent("validating", validating);
            descriptor.AddEvent("validated", validated);

            return new ScriptDescriptor[] { descriptor };
        }


        public IEnumerable<ScriptReference> GetScriptReferences()
        {

            // UserNameTextbox.js has been embeded and it will be compiled 
            // as a seperate assembly so it can be called via the following
            // codes rather than using the commented code
            ScriptReference reference = new ScriptReference();
            reference.Assembly = "JobRepo";
            reference.Name = "JobRepo.UserNameTextbox.js";

            return new ScriptReference[] { reference };

           // yield return new ScriptReference(Page.ClientScript
            //     .GetWebResourceUrl(this.GetType(), "JobRepo.UserNameTextbox.js"));
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!this.DesignMode)
            {
                sMgr = ScriptManager.GetCurrent(Page);

                if (sMgr == null)
                {
                    throw new HttpException(
                        "A ScriptManager control must exist on the page.");
                }
                sMgr.RegisterScriptControl(this);
            }

            base.OnPreRender(e);
        }


        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
                sMgr.RegisterScriptDescriptors(this);

            base.Render(writer);
        }

    }
}