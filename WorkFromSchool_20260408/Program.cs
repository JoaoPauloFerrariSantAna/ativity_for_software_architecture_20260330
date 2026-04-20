using System.Reflection;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;
using WorkFromSchool_20260408.BillingContext.Infrastructure.Repositories;

namespace WorkFromSchool_20260408;

public class Program
{
    private static void AddServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
        //builder.Services.AddScoped<IContaBancariaRepositiory, ContaBancariaRepository>();

        // solution (and thanks): https://www.crispy-engineering.com/p/registering-all-types-as-generic-interfaces-in-assembly-in-dotnet-core
        Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(a => a.Name.EndsWith("Repository") && !a.IsAbstract && !a.IsInterface)
            .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
            .ToList()
            .ForEach(typesToRegister =>
            {
                typesToRegister.serviceTypes.ForEach(typeToRegister => {
                    builder.Services.AddScoped(typeToRegister, typesToRegister.assignedType);
                });
            });
    }

    private static void ConfigureHttpPipeline(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(conf => conf.SwaggerEndpoint("/openapi/v1.json", "API v1"));
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.MapControllers();
    }

    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        WebApplication app = null;

        // Add services to the container.
        AddServices(builder);

        app = builder.Build();

        // Configure the HTTP request pipeline.
        ConfigureHttpPipeline(app);

        app.Run();
    }
}