using DemoMinimal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMinimal.Application
{
    public interface IConsumeApi
    {
        Task<Response> GetFoobarResponseAsync(Foobar foobar);
    }
}
