using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PortalPerfomanceEmployees.Data;
using PortalPerfomanceEmployees.Models;

namespace PortalPerfomanceEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public LoginController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(EmployeeLoginDTO empLogin)
        {
            var Employee = Autenticate(empLogin);
            if (Employee != null)
            {
                string token = GenerateToken(Employee);
                return Ok(token);
            }
            return NotFound("Username or password not found.");
        }

        private string GenerateToken(Employee emp)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, emp.Username),
                new Claim(ClaimTypes.Email, emp.EmailAddress),
                new Claim(ClaimTypes.GivenName, emp.FirstName),
                new Claim(ClaimTypes.Role, emp.Role.ToString())
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Employee? Autenticate(EmployeeLoginDTO emp)
        {
            var currentEmp = _context.Employees.FirstOrDefault(u => u.Username == emp.Username && u.Password == emp.Password);
            if (currentEmp != null)
            {
                return currentEmp;
            }
            return null;
        }

    }
}
