using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.DTOs;
using Project.Models;

namespace Project.Services
{
    public class StudentsServices
    {
        private readonly StudentRegistryDbContext context;

        public StudentsServices(StudentRegistryDbContext context)
        {
            this.context = context;
        }
        public List<StudentToCreateDTO> GetAllStudents()
        {
            var students = context.Students.Include(s => s.Address).ToList();
            var studentDTOs = new List<StudentToCreateDTO>();

            foreach (var student in students)
            {
                var studentDTO = new StudentToCreateDTO
                {
                    Id = student.Id,
                    Name = student.Name,
                    Surname = student.Surname,
                    Age = student.Age,
                };

                if (student.Address != null)
                {
                    studentDTO.Address = new AddressToCreateDTo
                    {
                        Id = student.Address.Id,
                        City = student.Address.City,
                        Street = student.Address.Street,
                        Number = student.Address.Number
                    };
                }

                studentDTOs.Add(studentDTO);
            }

            return studentDTOs;
        }
        public StudentToCreateDTO GetStudentById(int id)
        {
            var student = context.Students.Include(s => s.Address)
                .FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return null;
            }

            return new StudentToCreateDTO
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age,
                Address = new AddressToCreateDTo
                {
                    Id = student.Address.Id,
                    City = student.Address.City,
                    Street = student.Address.Street,
                    Number = student.Address.Number
                }
            };
        }

        public StudentToCreateDTO CreateStudent(StudentToCreateDTO studentDTO)
        {
            var student = new Student
            {
                Name = studentDTO.Name,
                Surname = studentDTO.Surname,
                Age = studentDTO.Age,
                Address = new Address
                {
                    City = studentDTO.Address.City,
                    Street = studentDTO.Address.Street,
                    Number = studentDTO.Address.Number
                }
            };

            context.Students.Add(student);
            context.SaveChanges();

            studentDTO.Id = student.Id;
            studentDTO.Address.Id = student.Address.Id;
            return studentDTO;
        }

        public void UpdateStudent(StudentToCreateDTO studentDTO)
        {
            var student = context.Students.Include(s => s.Address)
                .FirstOrDefault(s => s.Id == studentDTO.Id);

            if (student != null)
            {
                student.Name = studentDTO.Name;
                student.Surname = studentDTO.Surname;
                student.Age = studentDTO.Age;
                student.Address.City = studentDTO.Address.City;
                student.Address.Street = studentDTO.Address.Street;
                student.Address.Number = studentDTO.Address.Number;

                context.SaveChanges();
            }
        }

        public void DeleteStudent(int id)
        {
            var student = context.Students.Include(s => s.Address)
                .FirstOrDefault(s => s.Id == id);

            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }
    }
}
