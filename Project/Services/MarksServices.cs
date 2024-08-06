using Project.Data;
using Project.DTOs;
using Project.Models;


namespace Project.Services
{
    public class MarksServices
    {
        private readonly StudentRegistryDbContext context;

        public MarksServices(StudentRegistryDbContext context)
        {
            this.context = context;
        }

        public void AddMark(int studentId, int subjectId, int value)
        {
            var mark = new Mark
            {
                Value = value,
                DateGiven = DateTime.Now,
                StudentId = studentId,
                SubjectId = subjectId
            };

            context.Marks.Add(mark);
            context.SaveChanges();
        }

        public List<MarkToCreateDTo> GetMarksByStudent(int studentId)
        {
            return context.Marks
                .Where(m => m.StudentId == studentId)
                .Select(m => new MarkToCreateDTo
                {
                    Value = m.Value,
                    DateGiven = m.DateGiven,
                    SubjectName = m.Subject.Name
                }).ToList();
        }

        public List<MarkToCreateDTo> GetMarksByStudentAndSubject(int studentId, int subjectId)
        {
            return context.Marks
                .Where(m => m.StudentId == studentId && m.SubjectId == subjectId)
                .Select(m => new MarkToCreateDTo
                {
                    Value = m.Value,
                    DateGiven = m.DateGiven,
                    SubjectName = m.Subject.Name
                }).ToList();
        }

        public double GetAverageMarkByStudentAndSubject(int studentId, int subjectId)
        {
            return context.Marks
                .Where(m => m.StudentId == studentId && m.SubjectId == subjectId)
                .Average(m => m.Value);
        }
    }
}
