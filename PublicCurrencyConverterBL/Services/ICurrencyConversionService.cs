using PublicCurrencyConverterBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicCurrencyConverterBL.Services
{
    /// <summary>
    /// Interface for Currency conversion service
    /// </summary>
    public interface ICurrencyConversionService
    {
        double ConvertToTargetCurrency(string ApiBaseUrl, string apiKey, CurrencyConversionInputModel model);
    }
}
