using Microsoft.EntityFrameworkCore;
using TechConf.Data;
using TechConf.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Register Controller Service
builder.Services.AddControllers();

ConfigureServices.RegisterRepositories(builder.Services);
ConfigureServices.RegisterServices(builder.Services);
ConfigureServices.RegisterMappers(builder.Services);

// Register DbContext
builder.Services.AddDbContext<TechConfDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("TechConfDb");
    options.UseSqlite(connectionString);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
