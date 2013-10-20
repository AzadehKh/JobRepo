using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.IO;
using System.Xml.Linq;
using System.ServiceModel.Web;
using System.Runtime.Serialization.Json;
using JobRepo.Model;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;

namespace JobRepo.Services
{
    /*
     * A useful blog about ECF Raw Programming mode can be found here:
     * http://blogs.msdn.com/b/carlosfigueira/archive/2008/04/17/wcf-raw-programming-model-web.aspx
     * */
    //[ServiceContract(Namespace="http://localhost:8080/JobRepo/KeywordsPopularity"])


    /*
     * By default , this service can not be in another library as it causes a cross-domain call to a WCF REST service
     * In order to be able to do this , see here: 
     * http://blogs.microsoft.co.il/blogs/idof/archive/2011/07/02/cross-origin-resource-sharing-cors-and-wcf.aspx
    */
    [ServiceContract(Namespace = "KeywordsPopularityServices")]
    public interface IKeywordsPopularityRESTService
    {
        /*
            [OperationContract(Name = "GetPopularity")] 
             if we have a SOAP Service ,  We need to change property Name of operationContract
            as WebMessageFormat have two methods with the same name in our .NET code
        */
        [WebGet(ResponseFormat = WebMessageFormat.Json
        , UriTemplate = "KeywordsPopularity/{keyword}")]
        KeywordsPopularityDto GetKeywordsPopularity(string Keyword);

        [WebGet(ResponseFormat = WebMessageFormat.Xml
        , UriTemplate = "KeywordsPopularity/xml")]
        [OperationContract(Name = "GetPopularityAsXML")]
         XElement GetKeywordsPopularity();

        [WebGet(UriTemplate = "KeywordsPopularity/json/version1"
        , ResponseFormat = WebMessageFormat.Json)]
        [OperationContract(Name = "GetPopularityAsJSONV1")]
         string GetKeywordsPopularityAsJSONV1();


        /*
         * Set the response format to ResponseFormat = WebMessageFormat.Json
         * is enough to return JSON
         * 
         * The restun value cannot be IEnumerable rathen than List
         * */
        [WebGet(UriTemplate = "KeywordsPopularity/json/version2"
        , ResponseFormat = WebMessageFormat.Json)]
        [OperationContract(Name = "GetPopularityAsJSONV2")]
         List<KeywordsPopularityDto> GetKeywordsPopularityAsJSONV2();

        //[WebGet]
        // Stream GetValueAsStream();
        /*
         *  an on the client side it should be used as follows:
           <img src=""  id="image1" width="500" height="400" />
            function ShowImage() {// Call the WCF service
                   $("#image1").attr('src', 
            'service/KeywordsPopularityRESTService.svc/GetValueAsStream');}
         * 
         */
    }

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class KeywordsPopularityRESTService : IKeywordsPopularityRESTService
    {



        public KeywordsPopularityDto GetKeywordsPopularity(string Keyword)
        {

            //Keyword = System.Uri.UnescapeDataString(Keyword); 

            Keyword = Keyword.Replace("[Keyword]", ".");
            using (JobRepoDataContext context = new JobRepoDataContext())
            {
                /*
                 * LINQ to Entity does not support ToString() when we need Count  = pop.Count.ToString()
                 * to fix this problem we need to get data as Objct (var tempobject) and LINQ to Object 
                 * support Tostring()
                 */
                var tempobject = from pop in context.KeywordPopularities
                                                             .Where( e =>e.Keyword.Equals(Keyword))
                                                             select new 
                                                             {
                                                                 Keyword = pop.Keyword,
                                                                 Count = pop.Count
                                                             };



                IEnumerable<KeywordsPopularityDto> popJson = (from pop in tempobject.AsEnumerable()
                                                             select new KeywordsPopularityDto
                                                             {
                                                                 Keyword = pop.Keyword,
                                                                 Count = pop.Count.ToString()
                                                             }).ToList();
                return popJson.FirstOrDefault();
            }

        }



        public XElement GetKeywordsPopularity()
        {
            XElement popXml = null;
            using (JobRepoDataContext context = new JobRepoDataContext())
            {

                //popXml = new
                //XElement("KeywordPopularities", from pop in context.KeywordPopularities
                //                                select new
                //                                XElement("KeywordPopularities",
                //                                new XElement("Keyword", pop.Keyword),
                //                                new XElement("Count", pop.Count + "")
                //                                ));

                /*
                 * The aobve code does not work becuase We're using an XElement constructor that takes parameters 
                 * in our "select" clause. Since XElement doesn't have a parameterless constructor,
                 * we might need to change your code to select an anonymous type,
                 * and initialize the XElement collection after the fact so 
                 * we should do the EF query first, and then calling ToList() on it 
                 * so that I can select the XElement collection using Linq to Objects rather than EF
                 * http://stackoverflow.com/questions/3464035/what-does-the-parameterless-constructors-and-initializers-are-supported
                 * */

                var els = from pop in context.KeywordPopularities
                          .OrderBy(e => e.Keyword)
                          select new { pop.Keyword, pop.Count };

                popXml = new XElement("KeywordPopularities",
                     els.ToList()
                        .Select(e => new XElement("KeywordPopularity",
                                         new XElement("Keyword", e.Keyword),
                                                 new XElement("Count", e.Count + "")
                                         )));


            }
            return popXml;
        }


        public string GetKeywordsPopularityAsJSONV1()
        {

            using (JobRepoDataContext context = new JobRepoDataContext())
            {
                //IEnumerable<KeywordPopularity> popJson = from pop in context.KeywordPopularities
                //                                        select pop;
                //DataContractJsonSerializer ser =
                //  new DataContractJsonSerializer(typeof(IEnumerable<KeywordPopularity>)); 

                /*
                 * You cannot return an IEnumerable of type KeywordPopularity because 
                 * EF entities cannot be serialized by default  and we must add code generation to them
                 * so instead of returning an ADO.NET entity ,  we can do one of the following solutions:
                 *  1 - Create a DTO object which is decorated either by Attribute [DataContract] or [Serializable] can fixed out problem as we will have a Serializable object
                 *  2 - Using the second GetKeywordsPopularityAsJSONV2
                 *  
                 * But if you still want to know how to create Serializable entities please see
                  http://msdn.microsoft.com/en-us/library/ff407090.aspx
                 * 
                */
                IEnumerable<KeywordsPopularityDto> popJson = from pop in context.KeywordPopularities
                                                             .OrderBy(e => e.Keyword)
                                                             select new KeywordsPopularityDto
                                                             {
                                                                 Keyword = pop.Keyword,
                                                                 Count = pop.Count + ""
                                                             };


                DataContractJsonSerializer ser =
                  new DataContractJsonSerializer(typeof(IEnumerable<KeywordsPopularityDto>));
                MemoryStream ms = new MemoryStream();
                ser.WriteObject(ms, popJson);

                string json = Encoding.Default.GetString(ms.ToArray());
                ms.Close();


                //HttpContext.Current.Response
                // Response
                WebOperationContext.Current.OutgoingResponse.ContentType
                    = "application/json; charset=utf-8";
                return json;
            }

        }


        public List<KeywordsPopularityDto> GetKeywordsPopularityAsJSONV2()
        {

            using (JobRepoDataContext context = new JobRepoDataContext())
            {

                IEnumerable<KeywordsPopularityDto> popJson = from pop in context.KeywordPopularities
                                                             .OrderBy(e => e.Keyword)
                                                             select new KeywordsPopularityDto
                                                             {
                                                                 Keyword = pop.Keyword,
                                                                 Count = pop.Count + ""
                                                             };




                return popJson.ToList();
            }

        }


      //public Stream GetValueAsStream()
      //{
      //    WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
      //    return new MemoryStream(Encoding.UTF8.GetBytes(Value.ToString()));
      //}
    }


    [DataContract]
    public class KeywordsPopularityDto
    {
        public KeywordsPopularityDto()
        {
        }

        [DataMember]
        public String Keyword { get; set; }
        [DataMember]
        public string Count { get; set; }
    }
}
