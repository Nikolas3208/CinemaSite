using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSite.Client
{
    public class Client
    {
        public HttpClientSettings HttpClientSettings { get; set; }
        public Client(HttpClientSettings httpClientSettings)
        {
            HttpClientSettings = httpClientSettings;

            Http = new HttpClient();
            Http.BaseAddress = httpClientSettings.BaseAddress;
            foreach(var header in httpClientSettings.Headers)
            {
                Http.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        public HttpClient Http { get; set; }

        public void AddHeader(string name, string value)
        {
            if(!HttpClientSettings.Headers.ContainsKey(name))
            {
                HttpClientSettings.Headers.Add(name, value);
                Http.DefaultRequestHeaders.Add(name, value);
            }
            else
            {
                if (HttpClientSettings.Headers[name] != value)
                {
                    HttpClientSettings.Headers[name] = value;
                    if(Http.DefaultRequestHeaders.Contains(name))
                    {
                        Http.DefaultRequestHeaders.Remove(name);
                    }
                    Http.DefaultRequestHeaders.Add(name, value);
                }
            }
        }
    }
}
