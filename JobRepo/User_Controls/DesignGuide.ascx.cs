using System;
using System.Web.UI;
using System.Net;
using System.IO;
using System.Web;

namespace JobRepo.User_Controls
{
    
    [ToolboxData(@"<{0}:DesignGuide runat=""server"" HTMLPageName=""""  />")]
    public partial class DesignGuide : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        string _HTMLPageName = "";
        public string HTMLPageName
        {
            get { return _HTMLPageName; }

            set 
            { 
                _HTMLPageName = value;

                if (!String.IsNullOrEmpty(_HTMLPageName))
                {
//                    if (Request.IsSecureConnection) 
//                      string url = string.Format("https://{0}{1}", Request.Url.Host, Page.ResolveUrl(_HTMLPageName));
//                    else
//                      string url = string.Format("http://{0}{1}", Request.Url.Host, Page.ResolveUrl(_HTMLPageName));
                    string url = string.Format(Request.Url.AbsoluteUri.Replace( Request.Url.AbsolutePath,"/Documents" + Page.ResolveUrl(_HTMLPageName)));
                    WebRequest req = WebRequest.Create(url);
                    WebResponse res = null;
                    try
                    {
                        res = req.GetResponse();
                    }
                    catch
                    {
                        url = url.Replace("Administration/", "").Replace("Account/" , "");
                        req = WebRequest.Create(url);
                        res = req.GetResponse();
                    }
                    
                    StreamReader sr = new StreamReader(res.GetResponseStream());
                    string html = sr.ReadToEnd();


                    
                    //litContent.Text = HttpUtility.HtmlEncode(html);
                    // HTMLEncode should not been used in this case 
                    litContent.Text = html;
                    sr.Close();
                    res.Close();
                }
            }
        }
    }
}