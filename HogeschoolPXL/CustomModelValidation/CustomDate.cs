using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.CustomModelValidation
{
    public class CustomDate : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var dtm = DateTime.Now;
            var lst = new List<ModelValidationResult>();
            if (DateTime.TryParse(context.Model.ToString(), out dtm))
            {
                if (dtm > new DateTime(DateTime.Now.Year, 10 ,1))
                {
                    lst.Add(new ModelValidationResult("", "Datum mag niet na 1/10/Huidigjaar!"));
                }
                else if (dtm < new DateTime(1980, 1, 1))
                {
                    lst.Add(new ModelValidationResult("", "Datum mag niet voor 1 january 1980!"));
                }              
            }
            else
            {
                lst.Add(new ModelValidationResult("", "Not valid date!"));
            }
            return lst;
        }
    }
}
