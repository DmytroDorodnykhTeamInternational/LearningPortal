// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalPerfomanceEmployees.Data;
using PortalPerfomanceEmployees.Models;

namespace PortalPerfomanceEmployees.Controllers
{
    [Route("UserController")]
    public class UserInfoController : Controller
    {
        private readonly EmployeeContext _context;

        public UserInfoController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("colleagues/")]
        public async Task<JsonResult> ShowTeamInfo(int? id)
        {
            var emp = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);
            if (emp == null)
            {
                return Json("Employee with that ID was not found");
            }
            else if (emp.Role == Role.Teamlead || emp.Role == Role.Employee)
            {
                var empList = await _context.Employees
                        .Where(e => e.TeamId == emp.TeamId)
                        .ToListAsync();
                return Json(empList);
            }
            else if (emp.Role == Role.Admin)
            {
                return Json(await _context.Employees.ToListAsync());
            }
            return Json("Something went wrong");
        }

        [HttpGet]
        [Route("user/")]
        public async Task<JsonResult> ShowUserInfo(int? id, int? idOfInterest)
        {
            var user = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);
            var personOfInterest = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == idOfInterest);
            if (user == null || personOfInterest == null)
            {
                return Json("Employee with that ID was not found");
            }
            if (user.Role == Role.Admin)
            {
                return Json(personOfInterest);
            }
            if (user.TeamId == personOfInterest.TeamId)
            {
                return Json(personOfInterest);
            }
            return Json("Access denied. You do not have the appropriate permissions.");
        }
    }
}
