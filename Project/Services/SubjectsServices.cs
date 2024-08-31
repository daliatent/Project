using Project.Data;
using Project.DTOs;
using Project.Models;

namespace Project.Services
{
    public class SubjectsServices
    {
        private readonly StudentRegistryDbContext context;

        public SubjectsServices(StudentRegistryDbContext context)
        {
            this.context = context;
        }

         public SubjectToCreateDTo AddSubject(SubjectToCreateDTo subjectDTO)
         {
             var subject = new Subject { Name = subjectDTO.Name };
             context.Subjects.Add(subject);
             context.SaveChanges();
             subjectDTO.Id = subject.Id;
             return subjectDTO;
         }
        
        
        public List<SubjectToCreateDTo> GetAllSubjects()
        {
            return context.Subjects.Select(s => new SubjectToCreateDTo
            {
                Id = s.Id,
                Name = s.Name
            }).ToList();
        }
        public Subject GetSubjectById(int id)
        {
            return context.Subjects.FirstOrDefault(s => s.Id == id);
        }

        public void DeleteSubject(int id)
        {
            var subject = context.Subjects.FirstOrDefault(s => s.Id == id);
            if (subject != null)
            {
                context.Subjects.Remove(subject);
                context.SaveChanges();
            }
        }

        public void UpdateSubject(int id, SubjectToCreateDTo subjectDTO)
        {
            var subject = context.Subjects.FirstOrDefault(s => s.Id == id);
            if (subject != null)
            {
                subject.Name = subjectDTO.Name;
                context.SaveChanges();
            }
        }
    }
}
