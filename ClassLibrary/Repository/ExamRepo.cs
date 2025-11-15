using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.model;

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
    }
}
