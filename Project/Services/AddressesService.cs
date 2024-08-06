using Project.Data;
using Project.DTOs;

namespace Project.Services
{
    public class AddressesService
    {
        private readonly StudentRegistryDbContext context;
        public AddressesService(StudentRegistryDbContext context)
        {
            this.context = context;
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
