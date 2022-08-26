using PortalPerfomanceEmployees.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var DevelopmentSpecificOrigins = "_developmentSpecificOrigins";
var ProductionSpecificOrigins = "_productionSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(DevelopmentSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                      });
    options.AddPolicy(ProductionSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("").AllowAnyMethod().AllowAnyHeader();
                      });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

            };
        });

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMvc();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddUserSecrets<Program>(true);
builder.Services.AddDbContext<PortalPerfomanceEmployees.Data.AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDbString")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(DevelopmentSpecificOrigins);
}
else if (app.Environment.IsProduction())
{
    app.UseCors(ProductionSpecificOrigins);
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();