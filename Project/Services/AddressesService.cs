using Project.Data;
using Project.DTOs;
using Project.Exceptions;

namespace Project.Services
{
    public class AddressesService
    {
        private readonly StudentRegistryDbContext context;
        public AddressesService(StudentRegistryDbContext context)
        {
            this.context = context;
        }
        public void ChangeStudent(int addressId, int studentId)
        {
            var studentExists = context.Students.Any(s => s.Id == studentId);
            if (!studentExists)
            {
              throw new StudentIdNotExistException("StudentId does not exist");
            }
            var address = context.Addresses.FirstOrDefault(a => a.Id == addressId);
            if (address != null)
            {
                address.StudentId = studentId;
            }
            context.SaveChanges();
        }

        public AddressToCreateDTo GetAddressByStudentId(int studentId)
        {
            var address = context.Addresses.FirstOrDefault(a => a.StudentId == studentId);
            if (address == null)
            {
                return null;
            }

            return new AddressToCreateDTo
            {
                Id = address.Id,
                City = address.City,
                Street = address.Street,
                Number = address.Number
            };
        }

        public void UpdateAddress(int studentId, AddressToCreateDTo addressDTO)
        {
            var address = context.Addresses.FirstOrDefault(a => a.StudentId == studentId);

            if (address != null)
            {
                address.City = addressDTO.City;
                address.Street = addressDTO.Street;
                address.Number = addressDTO.Number;

                context.SaveChanges();
            }
        }
    }
}
