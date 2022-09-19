using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using PortalPerfomanceEmployees.Data;
using PortalPerfomanceEmployees.Models;
using PortalPerfomanceEmployees.Repository;

namespace PortalPerfomanceEmployees.Services
{
    public class LoginServices
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly IConfiguration _config;
        private readonly int tokenLifeSpan = 10;
        public LoginServices(EmployeeRepository employeeRepository, IConfiguration configuration)
        {
            _employeeRepository = employeeRepository;
            _config = configuration;
        }
        public string Login(EmployeeLoginDTO empLogin)
        {
            var Employee = Autenticate(empLogin);
            if (Employee != null)
            {
                return GenerateToken(Employee);
            }
            return "";
        }

        public string RefreshToken(string oldToken)
        {
            var handler = new JwtSecurityTokenHandler();
            if (handler.CanReadToken(oldToken))
            {
                var jwtSecurityToken = handler.ReadJwtToken(oldToken);
                var userId = jwtSecurityToken.Claims.First(claim => claim.Type.Equals(ClaimTypes.NameIdentifier)).Value;


                if (int.TryParse(userId, out int empId))
                {
                    var emp = _employeeRepository.GetById(empId);
                    if (emp != null)
                    {
                        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        var claims = new[]
                        {
                        new Claim(ClaimTypes.NameIdentifier, emp.Id.ToString()),
                        new Claim(ClaimTypes.Email, emp.EmailAddress),
                        new Claim(ClaimTypes.GivenName, emp.FirstName),
                        new Claim(ClaimTypes.Role, emp.Role.ToString())
                    };
                        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                          _config["Jwt:Audience"],
                          claims,
                          expires: DateTime.Now.AddMinutes(tokenLifeSpan),
                          signingCredentials: credentials);
                        return new JwtSecurityTokenHandler().WriteToken(token);
                    }
                }
                return "";
            }
            return "";
        }
        private string GenerateToken(Employee emp)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, emp.Id.ToString()),
                new Claim(ClaimTypes.Email, emp.EmailAddress),
                new Claim(ClaimTypes.GivenName, emp.FirstName),
                new Claim(ClaimTypes.Role, emp.Role.ToString())
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(tokenLifeSpan),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Employee? Autenticate(EmployeeLoginDTO emp)
        {
            var currentEmp = _employeeRepository.VerifyEmployeeLogin(emp.Username, emp.Password);
            if (currentEmp != null)
            {
                return currentEmp;
            }
            return null;
        }
    }
}
