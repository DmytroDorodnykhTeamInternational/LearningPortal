using PortalPerfomanceEmployees.Startup;

var DevelopmentSpecificOrigins = "_developmentSpecificOrigins";
var ProductionSpecificOrigins = "_productionSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets<Program>(true);
builder.Services.RegisterServices(builder.Configuration);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseCors(DevelopmentSpecificOrigins);
    app.SeedData();
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