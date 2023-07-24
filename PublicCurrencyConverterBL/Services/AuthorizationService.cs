using PublicCurrencyConverterBL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicCurrencyConverterBL.Services
{
    /// <summary>
    /// Authorization service - API Key based authorization
    /// </summary>
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IRequestHelper _requestHelper;

        public AuthorizationService()
        {
            _requestHelper = new RequestHelper();
        }
        public async Task<bool> Authorize(string ApiUrl, string ApiKey)
        {
            return _requestHelper.Authorize(ApiUrl, ApiKey);
        }
    }
}
