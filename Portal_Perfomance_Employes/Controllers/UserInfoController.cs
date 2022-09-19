using PortalPerfomanceEmployees.Services;
using Microsoft.AspNetCore.Authorization;
using PortalPerfomanceEmployees.Models;
using Microsoft.AspNetCore.Mvc;

namespace PortalPerfomanceEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserInfoController : ControllerBase
    {
        private readonly UserInfoServices _userInfoServices;

        public UserInfoController(UserInfoServices userInfoServices)
        {
            _userInfoServices = userInfoServices;
        }

        [Route("GetUserRole")]
        [HttpGet]
        public async Task<IActionResult> GetUserRole()
        {
            try
            {
                string role = _userInfoServices.GetUserRole(User);
                if (!string.IsNullOrEmpty(role))
                    return Ok(role);
                return
                    NotFound();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [Route("GetUserProfile")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfile()
        {
            try
            {
                var emp = _userInfoServices.GetUserProfile(User);
                if (emp != null)
                    return Ok(emp);
                return
                    StatusCode(403, "Error! Token is corruptor id not found");
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [Route("GetEmployeeProfile")]
        [HttpGet]
        public async Task<IActionResult> GetEmployeeProfile(int targetId)
        {
            try
            {
                var emp = _userInfoServices.GetEmployeeProfile(targetId, User);
                if (emp != null)
                    return Ok(emp);
                return NotFound("Employee with specified ID was not found");
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [Route("GetUserColleagues")]
        [HttpGet]
        public async Task<IActionResult> GetUserColleagues()
        {
            try
            {
                var empList = _userInfoServices.GetUserColleagues(User);
                if (empList != null)
                    return Ok(empList);
                else
                    return NotFound("Something went wrong");
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [Route("GetUserTeamName")]
        [HttpGet]
        public async Task<IActionResult> GetUserTeamName()
        {
            try
            {
                var teamName = _userInfoServices.GetUserTeamName(User);
                if (teamName != null)
                    return Ok(teamName);
                else
                    return NotFound("Something went wrong");
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [Route("GetUserTeamHistory")]
        [HttpGet]
        public async Task<IActionResult> GetUserTeamHistory()
        {
            try
            {
                var teamMembersList = _userInfoServices.GetUserTeamHistory(User);
                if (teamMembersList != null)
                    return Ok(teamMembersList);
                else
                    return NotFound("Something went wrong");
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [Route("UpdateUserProfile")]
        [HttpPost]
        public async Task<IActionResult> UpdateUserProfile(EmployeeUserUpdateDTO newEmp)
        {
            try
            {
                var emp = _userInfoServices.UpdateUserProfile(User, newEmp);
                if (emp != null)
                    return Ok(emp);
                else
                    return NotFound("Something went wrong");
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}