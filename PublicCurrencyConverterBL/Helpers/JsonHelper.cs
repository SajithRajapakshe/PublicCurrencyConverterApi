using Newtonsoft.Json;
using PublicCurrencyConverterBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace PublicCurrencyConverterBL.Helpers
{
    /// <summary>
    /// Helper for json serialize/deserialize
    /// </summary>
    public class JsonHelper : IJsonHelper
    {
        public ResponseData DeSerialize(string jsonString)
        {
            var responseData = JsonConvert.DeserializeObject<ResponseData>(jsonString);

            return responseData;
        }
    }
}
