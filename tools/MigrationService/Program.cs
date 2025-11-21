using MigrationService;
using MigrationService.Initializers;
using AspireDemo.Application.Common.Interfaces;
using AspireDemo.Infrastructure.Persistence;
using AspireDemo.Infrastructure.Persistence.Interceptors;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddHostedService<Worker>();

builder.Services
    .AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

builder.Services.AddScoped<ApplicationDbContextInitializer>();
builder.Services.AddScoped<EntitySaveChangesInterceptor>();
builder.Services.AddScoped<ICurrentUserService, MigrationUserService>();
builder.Services.AddSingleton(TimeProvider.System);

builder.AddSqlServerDbContext<ApplicationDbContext>("CleanArchitecture",
    null,
    options =>
    {
        var serviceProvider = builder.Services.BuildServiceProvider();
        options.AddInterceptors(
            serviceProvider.GetRequiredService<EntitySaveChangesInterceptor>());
    });


var host = builder.Build();

await host.RunAsync();