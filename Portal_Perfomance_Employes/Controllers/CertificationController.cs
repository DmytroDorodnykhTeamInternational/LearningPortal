using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalPerfomanceEmployees.Data;
using PortalPerfomanceEmployees.Models;

namespace PortalPerfomanceEmployees.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class CertificationController : Controller
{
    private readonly AppDbContext _context;
    public CertificationController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetCertifications()
    {
        return Ok(await _context.Certifications.ToListAsync());
    }

    [HttpGet("{certificationId}")]
    public async Task<IActionResult> GetCertifications(int certificationId)
    {
        var cert = await _context.Certifications.FirstOrDefaultAsync(cert => cert.CertificationId == certificationId);
        return cert != null ? Ok(cert) : NotFound("That certificate ID does not exist");
    }

    [HttpGet("/getEmployeeCertifications/{employeeId}")]
    public async Task<IActionResult> GetEmployeeCertifications(int employeeId)
    {
        var emp = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == employeeId);
        if (emp == null) return NotFound("This employee does not exist");
        var empCerts = await _context.EmployeeCertifications
            .Where(ec => ec.EmployeeId == employeeId).ToListAsync();
        if (empCerts.Count == 0) return Ok("This employee does not have any certifications");
        var certDtos = new List<CertificationDTO>();
        foreach (var empCert in empCerts)
        {
            var cert = await _context.Certifications
                .FirstOrDefaultAsync(c => c.CertificationId == empCert.CertificationId);
            if (cert != null)
            {
                certDtos.Add(new CertificationDTO
                {
                    CertificationName = cert.CertificationName,
                    CertificationSkillId = cert.CertificationSkillId
                });
            }
        }
        return Ok(certDtos.ToList());
    }

    [HttpPost("createCertification")]
    public async Task<IActionResult> CreateCertification(int skillId, string certificationName)
    {
        if (await _context.Certifications
            .FirstOrDefaultAsync(c => c.CertificationName == certificationName) != null) return BadRequest("This certification already exists");
        if (await _context.Skills
            .FirstOrDefaultAsync(s => s.SkillId == skillId) == null) return NotFound("A skill with this ID does not exist");
        var newCertification = new Certification
        {
            CertificationName = certificationName
        };
        // save to assign ID
        await _context.Certifications.AddAsync(newCertification);
        await _context.SaveChangesAsync();
        var createdCert = await _context.Certifications.FirstOrDefaultAsync(c => c.CertificationName == certificationName);
        var newLink = new CertificationSkill
        {
            SkillId = skillId,
            CertificationId = createdCert.CertificationId
        };
        // save to assign ID
        await _context.CertificationSkills.AddAsync(newLink);
        await _context.SaveChangesAsync();
        var createdLink = await _context.CertificationSkills.FirstOrDefaultAsync(cs => cs.SkillId == skillId && cs.CertificationId == createdCert.CertificationId);
        createdCert.CertificationSkillId = createdLink.CertificationSkillId;
        await _context.SaveChangesAsync();
        return Ok(await GetCertifications());
    }

    [HttpPost("grantCertification")]
    public async Task<IActionResult> GrantCertification(int certificationId, int employeeId, DateTime dateCertified, string certificateUrl)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(employee => employee.Id == employeeId);
        if (employee == null) return NotFound("This employee does not exist");
        var cert = await _context.Certifications
            .FirstOrDefaultAsync(cert => cert.CertificationId == certificationId);
        if (cert == null) return NotFound("This certification does not exist");
        var existingCert = await _context.EmployeeCertifications.FirstOrDefaultAsync(c => c.CertificationId == certificationId && c.EmployeeId == employeeId);
        if (existingCert != null) return BadRequest("This employee already has this certification");
        var newCert = new EmployeeCertification
        {
            CertificateUrl = certificateUrl,
            CertificationId = certificationId,
            DateCertified = dateCertified,
            EmployeeId = employeeId
        };
        _context.EmployeeCertifications.Add(newCert);
        employee.EmployeeCertifications.Add(newCert);
        await _context.SaveChangesAsync();
        return Ok(newCert);
    }

    [HttpDelete("removeCertification")]
    public async Task<IActionResult> RemoveCertification(int certificationId, int employeeId)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(employee => employee.Id == employeeId);
        if (employee == null) return NotFound("This employee does not exist");
        var certification = await _context.EmployeeCertifications.FirstOrDefaultAsync(ec => ec.CertificationId == certificationId);
        if (certification == null) return BadRequest("This employee does not have this certification");
        employee.EmployeeCertifications.Remove(certification);
        _context.EmployeeCertifications.Remove(certification);
        await _context.SaveChangesAsync();
        return Ok(await GetCertifications());
    }

    [HttpDelete("deleteCertification")]
    public async Task<IActionResult> DeleteCertification(int certificationId)
    {
        var certification = await _context.Certifications.FirstOrDefaultAsync(c => c.CertificationId == certificationId);
        if (certification == null) return NotFound("This certification does not exist");
        var links = await _context.CertificationSkills.Where(cs => cs.CertificationId == certificationId).ToListAsync();
        var existingCerts = await _context.EmployeeCertifications.Where(ec => ec.CertificationId == certificationId).ToListAsync();
        if (links.Count != 0)
        {
            foreach (var link in links)
            {
                _context.CertificationSkills.Remove(link);
            }
        }
        if (existingCerts.Count != 0)
        {
            foreach (var cert in existingCerts)
            {
                _context.EmployeeCertifications.Remove(cert);
            }
        }
        _context.Certifications.Remove(certification);
        await _context.SaveChangesAsync();
        return Ok(await GetCertifications());

    }
}
