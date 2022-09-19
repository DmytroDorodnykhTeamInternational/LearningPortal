using Microsoft.AspNetCore.Authentication.JwtBearer;
using PortalPerfomanceEmployees.Config.Swagger;
using PortalPerfomanceEmployees.Config.Mapper;
using PortalPerfomanceEmployees.Repository;
using PortalPerfomanceEmployees.Services;
using Microsoft.IdentityModel.Tokens;
using PortalPerfomanceEmployees.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AutoMapper;

namespace PortalPerfomanceEmployees.Startup
{
    public static class DependecyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            var DevelopmentSpecificOrigins = "_developmentSpecificOrigins";
            var ProductionSpecificOrigins = "_productionSpecificOrigins";
            services.AddCors(options =>
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                    options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = configuration["Jwt:Issuer"],
                            ValidAudience = configuration["Jwt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                        };
                    }
            );
            services.AddControllers().AddNewtonsoftJson(jsonOptions => jsonOptions.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSingleton(new MapperConfiguration(cfg => { cfg.AddProfile(new ConfigMapper()); }).CreateMapper());
            services.AddMvc();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(setup =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
                setup.OperationFilter<AuthResponsesOperationFilter>();
            });
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("EmployeeDbString"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();
                    });
            });
            services.AddScoped<SeedingService>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<EmployeeRepository>();
            return services;
        }

        public static void SeedData(this IHost app)
        {
            using(var scope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                var service = scope.ServiceProvider.GetService<SeedingService>();
                service.Seed();
            }
        }
    }
}
