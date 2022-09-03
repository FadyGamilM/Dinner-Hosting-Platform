using DinnerHostingPlatform.Application;
using DinnerHostingPlatform.Infrastructure;
using DinnerHostingPlatform.API.Middleware;
using DinnerHostingPlatform.API.Filters;

var builder = WebApplication.CreateBuilder(args);

{
    //! Inject the services from the Application Layer
    //! Inject the services from the Infrastructure Layer
    builder.Services.AddApplicationLayerDependencies()
                           .AddInfrastructureLayerDependencies(builder.Configuration);
    // Add services to the container.
    builder.Services.AddControllers(
        // use the errorHanldingFilter to handle exceptions on all controllers of this layer
        options => options.Filters.Add(new ErrorHandlingFilterAttribute())
    );
}

var app = builder.Build();

{
    //* if you need to use global error handling
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
