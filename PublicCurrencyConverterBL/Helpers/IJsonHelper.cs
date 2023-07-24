using PublicCurrencyConverterBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PublicCurrencyConverterBL.Helpers
{

    /// <summary>
    /// Serialize, deserialize json helper
    /// </summary>
    public interface IJsonHelper
    {
        ResponseData DeSerialize(string jsonString);
    }
}
