using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicCurrencyConverterBL.Services
{
    /// <summary>
    /// Interface for authorization service
    /// </summary>
    public interface IAuthorizationService
    {
        Task<bool> Authorize(string ApiUrl, string ApiKey);
    }
}
