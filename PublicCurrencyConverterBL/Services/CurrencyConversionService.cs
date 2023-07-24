using PublicCurrencyConverterBL.Helpers;
using PublicCurrencyConverterBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicCurrencyConverterBL.Services
{
    /// <summary>
    /// Service for currency conversion operations
    /// </summary>
    public class CurrencyConversionService : ICurrencyConversionService
    {
        private readonly IRequestHelper _requestHelper;
        public CurrencyConversionService()
        {
            _requestHelper = new RequestHelper();
        }

        /// <summary>
        /// Convert currency using the helper class and methods
        /// </summary>
        /// <param name="apiBaseUrl"></param>
        /// <param name="apiKey"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public double ConvertToTargetCurrency(string apiBaseUrl, string apiKey, CurrencyConversionInputModel model)
        {
            //Api giving values for single amount (1 USD, 1 EUR etc.). Multiply by the requested amount.
            var result = _requestHelper.Convert(apiBaseUrl, apiKey, model.BaseCurrency, model.TargetCurrency);
            if (result != null && result.data != null)
                return result.data.USD == 0 ? result.data.EUR * model.InputAmount : result.data.USD * model.InputAmount;
            else
                return 0;
        }
    }
}
