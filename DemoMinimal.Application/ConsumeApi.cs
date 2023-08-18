using DemoMinimal.Domain;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DemoMinimal.Application
{
    public class ConsumeApi : IConsumeApi
    {
        private readonly IConfiguration _config;
        public ConsumeApi(IConfiguration config)
        {
            _config = config;
        }
        public async Task<Response> GetFoobarResponseAsync(Foobar foobar)
        {
            var result = new Response();
            using var client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(_config.GetSection("ExternalApi:Url").Value, foobar);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Response>(content);
            }
            return result;
        }
    }
}
