using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechConf.Common.Constant;
using TechConf.Data;
using TechConf.Services.Contracts;
using TechConf.Web;

var allowedOrigins = "allowedOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Register Controller Service
builder.Services.AddControllers();
builder.Services.Configure<APIKeyOptions>(builder.Configuration.GetSection("APIKey"));
ConfigureServices.RegisterRepositories(builder.Services);
ConfigureServices.RegisterServices(builder.Services);
ConfigureServices.RegisterMappers(builder.Services);
builder.Services.AddCors(o =>
{
    o.AddPolicy(allowedOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
// Register DbContext
builder.Services.AddDbContext<TechConfDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("TechConfDb");
    options.UseSqlite(connectionString);
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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

app.UseCors(allowedOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
