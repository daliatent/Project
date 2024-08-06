using System.Net;

namespace Project.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
        public ICollection<Mark> Marks { get; set; }
    }
}
