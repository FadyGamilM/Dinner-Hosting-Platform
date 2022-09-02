using DinnerHostingPlatform.Application;
using DinnerHostingPlatform.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

{
    //! Inject the services from the Application Layer
    //! Inject the services from the Infrastructure Layer
    builder.Services.AddApplicationLayerDependencies()
                           .AddInfrastructureLayerDependencies(builder.Configuration);
    // Add services to the container.
    builder.Services.AddControllers();
}

var app = builder.Build();

{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
