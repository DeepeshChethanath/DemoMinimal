using DemoMinimal.Application;
using DemoMinimal.Domain;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IService, Service>();
builder.Services.AddTransient<IConsumeApi, ConsumeApi>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/posts",async (IService _svc, [FromBody]Foobar foobar) =>
{
    if (foobar.UserId == 0 && string.IsNullOrEmpty(foobar.Title))
        return Results.BadRequest("Title cannot be empty");
    Task<FoobarResponse> result = _svc.PostFoobar(foobar);
    return Results.Ok(result.Result);
}).WithName("Foobar")
.Accepts<Foobar>("application/json")
.Produces<FoobarResponse>(200)
.Produces(400);


app.Run();


