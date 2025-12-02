using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.model;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repository
{
    public class ExamRepo
    {
        private readonly DataAccess.ExamContext _context;

        public ExamRepo(DataAccess.ExamContext context)
        {
            _context = context;
        }

        public List<Exam> GetAll() => _context.Exams.ToList();

        public void Add(Exam exam)
        {
            _context.Exams.Add(exam);
            _context.SaveChanges();
        }

        public void Update(Exam exam)
        {
            _context.Exams.Update(exam);
            _context.SaveChanges();
        }

        public void Delete(Exam exam)
        {
            _context.Exams.Remove(exam);
            _context.SaveChanges();
        }

        public List<Exam> GetExamsByPersonId(int personId)
        {
            return _context.Exams
                .Include(e => e.Hold)
                .Include(e => e.Assignments)
                .Where(e => e.Assignments != null && e.Assignments.Any(a => a.PersonId == personId))
                .OrderBy(e => e.ExamDate)
                .ToList();
        }
    }
}
