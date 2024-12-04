using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.Client
{
    public class HttpClientSettings
    {
        public Dictionary<string, string> Headers = new Dictionary<string, string>();
        public Uri BaseAddress { get; set; }

        public void SetBaseAddress(string baseAddress)
        {
            BaseAddress = new Uri(baseAddress);
        }

        public void AddHeader(string name, string value)
        {
            Headers.Add(name, value);
        }
    }
}
