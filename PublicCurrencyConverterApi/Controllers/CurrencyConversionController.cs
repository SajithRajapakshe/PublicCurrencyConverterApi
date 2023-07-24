using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PublicCurrencyConverterBL.Models;
using PublicCurrencyConverterBL.Services;

namespace PublicCurrencyConverterApi.Controllers
{
    /// <summary>
    /// Currency conversion controller.
    /// </summary>
    public class CurrencyConversionController : ControllerBase
    {
        private readonly ICurrencyConversionService _currencyService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IConfiguration _configuration;

        private string ApiBaseUrl;
        private string ApiKey;


        /// <summary>
        /// Inject dependencies using DI - Constructor injection
        /// </summary>
        /// <param name="currencyService"></param>
        /// <param name="authorizationService"></param>
        /// <param name="configuration"></param>
        public CurrencyConversionController(ICurrencyConversionService currencyService, IAuthorizationService authorizationService, IConfiguration configuration)
        {
            _currencyService = currencyService;
            _authorizationService = authorizationService;
            _configuration = configuration;

            //Api details are added in the appsettings.json file.A free API key is created using my email address.
            ApiBaseUrl = _configuration.GetValue<string>("CurrencyApi:CurrencyApiBaseUrl");
            ApiKey = _configuration.GetValue<string>("CurrencyApi:CurrencyApiKey");
        }

        /// <summary>
        /// Currency convertion API method. This is the API end point any client application must reach to.
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PublicCurrencyConversionApi")]
        public async Task<double> ConvertCurrency([FromForm] CurrencyConversionInputModel inputModel)
        {
            if (await AuthorizeByApiKey())
                return _currencyService.ConvertToTargetCurrency(ApiBaseUrl, ApiKey, inputModel);

            return 0;
        }

        /// <summary>
        /// Authorizing by the provided free API Key.
        /// </summary>
        /// <returns></returns>
        private async Task<bool> AuthorizeByApiKey()
        {
            return await _authorizationService.Authorize(ApiBaseUrl, ApiKey);
        }
    }
}