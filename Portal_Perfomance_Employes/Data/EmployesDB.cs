using Portal_Perfomance_Employes.Models;

namespace Portal_Perfomance_Employes.Data
{
    public class EmployesDB
    {
        public List<Employe> employes { get; set; }
        public void PopularEmployesDB()
        {
            employes = new List<Employe>()
            {
                new Employe { Id = 1, Name = "Emp1", Age = 25 , level = seniority.Junior, Created = DateTime.Now},
                new Employe { Id = 2, Name = "Emp2", Age = 30 , level = seniority.mid_level, Created = DateTime.Now},
                new Employe { Id = 3, Name = "Emp3", Age = 35 , level = seniority.Senior, Created = DateTime.Now}
            };
        }
    }
}
