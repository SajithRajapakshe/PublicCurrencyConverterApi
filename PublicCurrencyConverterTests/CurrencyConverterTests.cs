using NUnit.Framework;
using PublicCurrencyConverterBL.Models;
using PublicCurrencyConverterBL.Services;

namespace PublicCurrencyConverterTests
{

    /// <summary>
    /// Simple unit test cases to validate authorization and currency conversion services
    /// </summary>
    public class CurrencyConverterTests
    {

        private IAuthorizationService _authorizationService;
        private ICurrencyConversionService _currencyConversionService;
        [SetUp]
        public void SetUp()
        {
            _authorizationService = new AuthorizationService();
            _currencyConversionService = new CurrencyConversionService();
        }

        [Test]
        [TestCase("https://api.freecurrencyapi.com/v1/", "fca_live_tcvEXXidClMxLhQzNKv2aMcVvxNXFNlmV6xCJIUe")]
        public void Authorize_Success(string url, string apiKey)
        {
            Assert.That(_authorizationService.Authorize(url, apiKey).Result, Is.True);
        }

        [Test]
        [TestCase("https://api.freecurrencyapi.com/v1234/", "fca_live_tcvEXXidClMxLhQzNKv2aMcVvxNXFNlmV6xCJIUe")]
        [TestCase("https://api.freecurrencyapi.com/v1/", "fca_live_tcvEXXidClMxLhQzNKv2aMc")]
        public void Authorize_Failure(string url, string apiKey)
        {
            Assert.That(_authorizationService.Authorize(url, apiKey).Result, Is.False);
        }

        [Test]
        [TestCase("https://api.freecurrencyapi.com/v1/", "fca_live_tcvEXXidClMxLhQzNKv2aMcVvxNXFNlmV6xCJIUe")]
        public void CurrencyConversion_Success(string url, string apiKey)
        {
            CurrencyConversionInputModel model = new CurrencyConversionInputModel()
            {
                BaseCurrency = "USD",
                TargetCurrency = "EUR",
                InputAmount = 100
            };

            double num = 0;
            bool result = double.TryParse(_currencyConversionService.ConvertToTargetCurrency(url, apiKey, model).ToString(), out num);

            bool hasValue = num > 0;

            Assert.That(result && hasValue, Is.EqualTo(true));
        }

        [Test]
        [TestCase("https://api.freecurrencyapi.com/v1/", "fca_live_tcvEXXidClMxLhQzNKv2aMcVvxNXFNlmV6xCJIUe")]
        public void CurrencyConversion_Failure(string url, string apiKey)
        {
            CurrencyConversionInputModel model = new CurrencyConversionInputModel()
            {
                BaseCurrency = "USDUSED",
                TargetCurrency = "EURO",
                InputAmount = 100
            };

            double num = 0;
            bool result = double.TryParse(_currencyConversionService.ConvertToTargetCurrency(url, apiKey, model).ToString(), out num);

            bool hasValue = num > 0;

            Assert.That(result && hasValue, Is.EqualTo(false));
        }


    }
}