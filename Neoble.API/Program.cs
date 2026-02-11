using Neoble.API.Configuration;

var builder = WebApplication.CreateBuilder(args);
ApiBootstrap.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();
ApiBootstrap.ConfigurePipeline(app);

app.Run();
