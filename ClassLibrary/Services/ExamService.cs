using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.model;
using ClassLibrary.Repository;

namespace ClassLibrary.Services
{
    public class ExamService : IExamService
    {
        private readonly ExamRepo _examRepo;

        public ExamService(ExamRepo examRepo)
        {
            _examRepo = examRepo;
        }

        public List<Exam> GetAllExams()
        {
            return _examRepo.GetAll();
        }

        public Exam GetExamById(int id)
        {
            var exams = _examRepo.GetAll();
            return exams.FirstOrDefault(e => e.Id == id);
        }

        public void AddExam(Exam exam)
        {
            ValidateExam(exam);
            _examRepo.Add(exam);
        }

        public void UpdateExam(Exam exam)
        {
            ValidateExam(exam);
            _examRepo.Update(exam);
        }

        private void ValidateExam(Exam exam)
        {
            if (string.IsNullOrWhiteSpace(exam.Name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(exam.Type))
            {
                throw new ArgumentException("Type cannot be empty");
            }
            if (exam.ExamDate == default(DateTime))
            {
                throw new ArgumentException("ExamDate must be set");
            }
        }

        public void DeleteExam(int id)
        {
            var exam = GetExamById(id);
            if (exam != null)
            {
                _examRepo.Delete(exam);
            }
        }

        public List<Exam> GetExamsByHoldId(int holdId)
        {
            var exams = _examRepo.GetAll();
            return exams.Where(e => e.HoldId == holdId).ToList();
        }
    }
}

