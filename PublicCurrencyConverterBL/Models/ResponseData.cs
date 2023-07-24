using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicCurrencyConverterBL.Models
{
    /// <summary>
    /// Response data - c# object of json response
    /// </summary>
    public class ResponseData
    {
        public Data data { get; set; }
    }
    public class Data
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }
    
}
