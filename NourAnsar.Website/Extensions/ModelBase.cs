using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NourAnsar.Website.Extensions
{
    //public class ModelBase
    //{
    //    public static IDictionary<string, string> GetValidationErrors(ModelStateDictionary model)
    //    {
    //        List<ModelStateEntry> modelStates = model.Root.Children.ToList();
    //        IDictionary<string, string> validationList = null;
    //        if (modelStates != null)
    //        {
    //            int i = 1;
    //            validationList = new Dictionary<string, string>();
    //            foreach (ModelStateEntry modelStateEntry in modelStates)
    //            {
    //                foreach (var error in modelStateEntry.Errors)
    //                {
    //                    validationList.Add(i.ToString(), error.ErrorMessage);
    //                    i++;
    //                }
    //            }
    //        }
    //        return validationList;
    //    }
    //}
    public class ModelBase
    {
        public static string GetValidationErrors(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary model)
        {

            string result = string.Empty;

            if (model != null)
            {
                foreach (Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry modelState in model.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        if (result.Length > 0)
                        {
                            result += "<br/>";
                        }
                        result += error.ErrorMessage.ToString();
                    }
                }
            }
            return result;
        }
    }
}
