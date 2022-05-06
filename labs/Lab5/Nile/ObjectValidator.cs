using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    public static class ObjectValidator
    {
        public static bool TryValidateObject ( object value, out IEnumerable<ValidationResult> results)
        {
            var context = new ValidationContext(value);
            var errors = new List<ValidationResult>();

            if(Validator.TryValidateObject(value, context, errors, true))
            {
                results = new ValidationResult[0];
                return true;
            };

            results = errors;
            return false;
        }
        public static void ValidateObject ( object value)
        {
            var context = new ValidationContext(value);

            Validator.ValidateObject(value, context, true);
        }
    }
}
