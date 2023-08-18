using DemoMinimal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMinimal.Application
{
    public class Service : IService
    {
        private readonly IConsumeApi _consumeApi;
        public Service(IConsumeApi consumeApi)
        {
            _consumeApi = consumeApi;
        }


        public async Task<FoobarResponse> PostFoobar(Foobar foobar)
        {
            var foobarResponse = new FoobarResponse();
            if (await _consumeApi.GetFoobarResponseAsync(foobar) != null)
            {
                foobarResponse.Status = "Success";
                foobarResponse.HttpStatusCode = 200;
                foobarResponse.Response = await _consumeApi.GetFoobarResponseAsync(foobar);
            }
            else
            {
                var error = new Error
                {
                    ErrorCode = "01",
                    ErrorMessage = "Post message unsuccessful"
                };

                foobarResponse.Status = "Failure";
                foobarResponse.HttpStatusCode = 400;
                foobarResponse.Error = error;
            }

            return foobarResponse;

        }
    }
}
