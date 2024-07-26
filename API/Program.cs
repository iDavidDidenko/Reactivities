// read from configuration files - appsettings.development.json + appsettings.json
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// we add here a new DB service
// DataContext the class we use to DBcontext
builder.Services.AddDbContext<DataContext>(ops =>
{
    // define the connection in - "appsettings.development.json"
    ops.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

// Configure the HTTP request pipeline. -- "middleware" 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


 app.UseAuthorization();

app.MapControllers();

// create the actuall DB based on what in Migration class.
// 1. get access to the server -> DataContext 

//Service scopes are used in dependency injection to manage the lifetime of services. 
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<DataContext>();
    //This applies any pending migrations to the database. This ensures that the database schema is up to date with the current model.
    await context.Database.MigrateAsync();
    await Seed.SeedData(context);
}
catch(Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An erroe occured during migration");
}

app.Run();
