namespace PortalPerfomanceEmployees.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Seniority Level { get; set; }
        public DateTime Created { get; set; }
    }

    public enum Seniority
    {
        Junior, MidLevel, Senior
    }
}
