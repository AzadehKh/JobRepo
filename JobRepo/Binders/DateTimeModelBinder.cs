using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobRepo.MVC.Binders
{
    public class DateTimeModelBinder: DefaultModelBinder// :IModelBinder
    {
        public DateTimeModelBinder()
        {

        }
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult result;
            result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (result == null)
                return null;

            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, result);

            DateTime datetimeresult;
            if (DateTime.TryParse(result.AttemptedValue, out datetimeresult))
            {
                return "Hello";
            }

            int intresult;
            if (int.TryParse(result.AttemptedValue, out intresult))
            {
                return "Bye";
                //return new DateTime(intresult, 1, 1);
            }

            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Could not convert data to datetime");
            return null;
        }
    }
}