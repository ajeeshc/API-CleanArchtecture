
using APIStructure.Filters;
//using APIStructure.Middleware;
using SampleAPI.Application;
using SampleAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
                .AddApplication()
                .AddInfrastructure(builder.Configuration);

    // if you need to register a filter across all controller in API
    // builder.Services.AddControllers(
    //    options => options.Filters.Add<ErrorHandlingFilterAttribute>()
    //    );

    builder.Services.AddControllers();

}

var app = builder.Build();
{
    // If you want to register a class in runtime
    // app.UseMiddleware<ErrorHandlingMiddleware>();

    // if you want to have a error controller to redirect. inbuilt apporach
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

