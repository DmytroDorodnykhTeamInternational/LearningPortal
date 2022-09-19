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
using PortalPerfomanceEmployees.Services;

namespace PortalPerfomanceEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginServices _logiinServices;

        public LoginController(LoginServices loginServices)
        {
            _logiinServices = loginServices;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(EmployeeLoginDTO empLogin)
        {
            if (empLogin == null) return BadRequest();
            if (string.IsNullOrWhiteSpace(empLogin.Username)) return BadRequest();
            if (string.IsNullOrWhiteSpace(empLogin.Password)) return BadRequest();
            try
            {
                string token = _logiinServices.Login(empLogin);
                if (!string.IsNullOrEmpty(token))
                    return Ok(token);
                return
                    NotFound();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [Route("RefreshToken")]
        [HttpPost]
        public IActionResult RefreshToken(string oldToken)
        {
            if (string.IsNullOrWhiteSpace(oldToken)) return BadRequest();
            try
            {
                string token = _logiinServices.RefreshToken(oldToken);
                if (!string.IsNullOrEmpty(token))
                    return Ok(token);
                return
                    NotFound();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
