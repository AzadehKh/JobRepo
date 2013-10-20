using System.Web.Mvc;
using System.Web.Routing;
using System.Collections.Generic;
using System.Web;
using System.Linq.Expressions;
using System.Linq;
using System;
namespace JobRepo.MVC.Controls
{
    public static class FileUploadHelper
    {

        public static TagBuilder FileUploader(this HtmlHelper htmlHelper, HttpPostedFileBase file)
        {

            var tagBuilder = new TagBuilder("input");
            tagBuilder.MergeAttribute("type", "file");
            tagBuilder.MergeAttribute("name", "File");

            if (file != null)
            {
                ModelState modelState;
                if (htmlHelper.ViewData.ModelState.TryGetValue(file.FileName, out modelState))
                {
                    if (modelState.Errors.Count > 0)
                    {
                        tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
                    }
                }
            }

            return tagBuilder;
        }

        //See here for more details:http://20fingers2brains.blogspot.com.au/2013/05/custom-password-html-helper-with-model.html
        //This overload accepts expression and htmlAttributes object as parameter.       
        public static MvcHtmlString FileUploader<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            //Fetching the metadata related to expression. This includes name of the property, model value of the property as well.            
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);

            //Fetching the property name.            
            string propertyName = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();


            //Creating a textarea tag using TagBuilder class.            
            var tagBuilder = new TagBuilder("input");

            //Setting the name and id attribute.            
            tagBuilder.Attributes.Add("name", propertyName);
            tagBuilder.Attributes.Add("id", propertyName);


            // This part is not applicable because:
            //1-	 The value here is the actual file which is a binary value not a string 
            //2-	This control is always empty when the page is rendered so it doesn’t have any default or initilized value 
            //Setting the value attribute of textbox with model value if present. 
            //if (metadata.Model != null)            
            //{
            //    tagBuilder.Attributes.Add("value", metadata.Model.ToString());            
            //}            

            //merging any htmlAttributes passed.            
            tagBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }


        //public static object FileUploader(this HtmlHelper htmlHelper, string FileName,  IDictionary<string, object> htmlAttributes)
        //{

        //    var tagBuilder = new TagBuilder("input");
        //    tagBuilder.MergeAttributes(htmlAttributes);
        //    tagBuilder.MergeAttribute("type", "file", true);
        //    tagBuilder.MergeAttribute("name", htmlAttributes[FileName]. , true);
        //    tagBuilder.GenerateId(filename);

        //    ModelState modelState;
        //    if (htmlHelper.ViewData.ModelState.TryGetValue(filename, out modelState))
        //    {
        //        if (modelState.Errors.Count > 0)
        //        {
        //            tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
        //        }
        //    }

        //    return tagBuilder.ToString(TagRenderMode.SelfClosing);
        //}

        //public static string FileUploader(this HtmlHelper htmlHelper, HttpPostedFileBase htmlAttributes)
        //{
        //    if (htmlAttributes != null)
        //    {
        //        Dictionary<string, HttpPostedFileBase> att = new Dictionary<string, HttpPostedFileBase>();
        //        att.Add(htmlAttributes.FileName, htmlAttributes);
        //        return htmlHelper.FileUploader(htmlAttributes.FileName, new RouteValueDictionary(att));
        //    }
        //    else
        //        return htmlHelper.FileUploader("", new RouteValueDictionary((object)null));
        //}



    }
}
