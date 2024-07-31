using API.Extenstions;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Note that there is only one parameter, config (not Services, we used THIS..)
// we will add the service there - AddApplicationServices
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline. -- "middleware" 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

// create the actuall DB based on what in Migration class.
// 1. get access to the server -> DataContext 

//Service scopes are used in dependency injection to manage the lifetime of services. 

// app.Services --> This is the IServiceProvider instance associated with the application.
// The purpose of creating a new scope is to manage the lifecycle of scoped services. 
/*
Scoped services are created once per request or per scope. 
When the scope ends, the services created within that scope are disposed of and released from memory. 
This ensures efficient resource management and avoids memory leaks.
*/

// the "using" to delete the Service after he finish deal with Mirgation
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
     //GetRequiredService --> Microsoft.Extensions.DependencyInjection
     var context = services.GetRequiredService<DataContext>();
     // MigrateAsync --> is an asynchronous method that applies any pending migrations to the database.
     await context.Database.MigrateAsync();
     await Seed.SeedData(context);
    }
    catch(Exception ex)
    {
     var logger = services.GetRequiredService<ILogger<Program>>();
     logger.LogError(ex, "An erroe occured during migration");
    }
};

//app.MapGet("/", () => "Hello World!");

app.Run();   
