using Cielo.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Cielo
{
    public class Error
    {
        public int Code { get; set; }

        public string Message { get; set; }
    }
}
