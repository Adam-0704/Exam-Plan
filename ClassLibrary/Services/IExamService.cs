using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.model;

namespace ClassLibrary.Services
{
    public interface IExamService
    {
        List<Exam> GetAllExams();
        Exam GetExamById(int id);
        Exam AddExam(Exam exam);
        void UpdateExam(Exam exam);
        void DeleteExam(int id);
        List<Exam> GetExamsByHoldId(int holdId);
    }
}

