namespace Project.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Mark> Marks { get; set; }
    }
}
