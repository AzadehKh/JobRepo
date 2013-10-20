using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel.Web;
using JobRepo.Services;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Xsl;
using System.Text;
using System.IO;

namespace JobRepo
{
    public partial class PopularityViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetKeywordsPopularity();
        }

        private void GetKeywordsPopularity()
        {


            XElement xmlelement = FetchDataFomService();
            if (xmlelement == null)
                return;

            XmlReader reader = xmlelement.CreateReader();

            string XSLTFile = Server.MapPath("PopularityViewer.xslt");
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(XSLTFile);

            if (xslt == null)
                return;

            StringBuilder result = new StringBuilder();
            TextWriter writer = new StringWriter(result);
            xslt.Transform(reader, null, writer);

            lblContainer.Text = result.ToString();

            reader.Close();
            writer.Close();

        }
        private XElement FetchDataFomService()
        {
            XElement result = null;
            /*  
                AS the application is using Built-in web server 
                to get the assigned port number, we need to get the address dynamically
                so the following code should be used to get the Base Url :
                Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath 
             */ 
            var request = HttpContext.Current.Request;
            WebChannelFactory<IKeywordsPopularityRESTService> cf
                 = new WebChannelFactory<IKeywordsPopularityRESTService>
            (new Uri(Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath 
                + "Services/KeywordsPopularityRESTServiceHost.svc"));

            IKeywordsPopularityRESTService client = cf.CreateChannel();
            try
            {
                result = client.GetKeywordsPopularity();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                Trace.Write("Internal Error: {0}", ex.Message);

            }

                return result;
        }
    }
}