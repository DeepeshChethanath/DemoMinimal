using DemoMinimal.Domain;

namespace DemoMinimal.Application
{
    public  interface IService
    {
        Task<FoobarResponse> PostFoobar(Foobar foobar);
    }
}
