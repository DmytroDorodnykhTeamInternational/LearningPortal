// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalPerfomanceEmployees.Data;
using PortalPerfomanceEmployees.Models;

namespace PortalPerfomanceEmployees.Controllers
{
    [Route("ShowUserInfo")]
    public class UserInfoController : Controller
    {
        private readonly EmployeeContext _context;

        public UserInfoController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<JsonResult> ShowUserInfo(int? id)
        {
            var emp = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);
            if (emp == null)
                return Json("Employee with that ID was not found");
            if (emp.Role == Role.Employee)
            {
                return Json(emp);
            }
            else if (emp.Role == Role.Teamlead)
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
    }
}
