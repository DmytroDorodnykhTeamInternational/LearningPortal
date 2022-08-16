namespace Portal_Perfomance_Employees.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public seniority level { get; set; }
        public DateTime Created { get; set; }

    }

    public enum seniority
    {
        Junior, mid_level, Senior
    }
}
