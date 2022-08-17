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
                          policy.WithOrigins("");
                      });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(DevelopmentSpecificOrigins);
}
else if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(ProductionSpecificOrigins);
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
