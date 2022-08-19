using PortalPerfomanceEmployees.Data;
using Microsoft.EntityFrameworkCore;

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

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddUserSecrets<Program>(true);
builder.Services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDbString")));

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
app.UseAuthorization();
app.MapControllers();
app.Run();