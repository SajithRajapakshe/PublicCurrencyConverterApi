using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PublicCurrencyConverterBL.Attributes
{
    /// <summary>
    /// Validator for amount validation- double value
    /// </summary>
    public class ValidateInputAmount : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return Regex.IsMatch(value.ToString(), "-?\\d+(\\.\\d{1,x})?");
        }
    }
}
