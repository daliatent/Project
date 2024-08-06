namespace Project.DTOs
{
    public class StudentToCreateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public AddressToCreateDTo Address { get; set; } 
    }
}
