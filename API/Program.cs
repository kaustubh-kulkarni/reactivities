using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//DbContext service
builder.Services.AddDbContext<DataContext>(opt => {
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

//When we are done with this scope everything is gonna get destroyed and free memory
using var scope = app.Services.CreateScope();
//Another var to scope to service provider
var services = scope.ServiceProvider;

try
{
    //Here need to get the DataContext service in order to perform the migration
    var context = services.GetRequiredService<DataContext>();
    //Migrate the DB
    await context.Database.MigrateAsync();
    await Seed.SeedData(context);
}
catch (Exception ex)
{
    //Creating a logger instance within the scope of program.cs to report logs
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration!");
}

app.Run();
