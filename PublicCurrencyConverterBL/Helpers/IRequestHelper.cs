using PublicCurrencyConverterBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicCurrencyConverterBL.Helpers
{
    /// <summary>
    /// Common request helper
    /// </summary>
    public interface IRequestHelper
    {
        bool Authorize(string ApiUrl, string ApiKey);
        ResponseData Convert(string ApiBaseUrl, string apiKey, string baseCurrency, string targetCurrency);
    }
}
