using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal_Perfomance_Employes.Data;
using Portal_Perfomance_Employes.Models;

namespace Portal_Perfomance_Employes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private EmployesDB _employesDB = new EmployesDB();

        public EmployeController()
        {
            _employesDB.PopularEmployesDB();
        }


        [HttpGet]
        public async Task<IEnumerable<Employe>> Get() => _employesDB.employes.ToList();
        
        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {

            Employe emp = _employesDB.employes.Find(x => x.Id == id);

            return emp == null ? NotFound() : Ok(emp) ;
        }


        [HttpPost]
        public async Task<IEnumerable<Employe>> CreateEmploye(Employe employe)
        {
            _employesDB.employes.Add(employe);
            return _employesDB.employes.ToList();
        }

        [HttpPut("{id}")]
        public async Task<IEnumerable<Employe>> UpdateEmploye(int id, Employe employe)
        {

            int index = _employesDB.employes.FindIndex(s => s.Id == id);

            if (index != -1)
                _employesDB.employes[index] = employe;
            
            return _employesDB.employes.ToList();
        }


        [HttpDelete("{id}")]
        public async Task<IEnumerable<Employe>> DeleteEmploye(int id)
        {

            int index = _employesDB.employes.FindIndex(s => s.Id == id);

            _employesDB.employes.RemoveAt(index);

            return _employesDB.employes.ToList();
        }

    }
}
