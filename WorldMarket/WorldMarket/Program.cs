using Microsoft.IdentityModel.Tokens;
using System.Text;
using WorldMarket.Extensions;
using WorldMarket.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson()
    .AddXmlSerializerFormatters() ;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureLogger();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureDatabaseContext();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "anvar-api",
            ValidAudience = "anvar-mobile",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("anvarSekretKalitSozMalades"))
        };
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    builder.Services.SeedDatabase(services);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
