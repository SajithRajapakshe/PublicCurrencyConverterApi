using PublicCurrencyConverterBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PublicCurrencyConverterBL.Helpers
{

    /// <summary>
    /// Request and Response related common operations
    /// </summary>
    public class RequestHelper : IRequestHelper
    {

        private readonly IJsonHelper _jsonHelper;

        public RequestHelper()
        {
            _jsonHelper = new JsonHelper();
        }

        /// <summary>
        /// Authorization function
        /// </summary>
        /// <param name="ApiBaseUrl"></param>
        /// <param name="ApiKey"></param>
        /// <returns></returns>
        public bool Authorize(string ApiBaseUrl, string ApiKey)
        {
            string url;
            url = ApiBaseUrl + "/status?apikey=" + ApiKey;

            return GetAuthorizationResponse(url);
        }


        /// <summary>
        /// Converting function
        /// </summary>
        /// <param name="ApiBaseUrl"></param>
        /// <param name="apiKey"></param>
        /// <param name="baseCurrency"></param>
        /// <param name="targetCurrency"></param>
        /// <returns></returns>
        public ResponseData Convert(string ApiBaseUrl, string apiKey, string baseCurrency, string targetCurrency)
        {
            string url;
            url = ApiBaseUrl + "/latest?currencies=" + targetCurrency + "&base_currency=" + baseCurrency + "&apikey=" + apiKey;

            var response = GetResponse(url);
            return _jsonHelper.DeSerialize(response);
        }


        /// <summary>
        /// Authorization response
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static bool GetAuthorizationResponse(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                return response.StatusCode == HttpStatusCode.OK;

            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    return httpResponse.StatusCode == HttpStatusCode.OK;
                }
            }
        }

        /// <summary>
        /// Content response
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string GetResponse(string url)
        {
            string jsonString;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    jsonString = reader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        jsonString = reader.ReadToEnd();
                    }
                }
            }


            return jsonString;
        }
    }
}
