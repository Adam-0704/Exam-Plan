using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.model
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Rolle { get; set; } = string.Empty;

        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
        public ICollection<ExamAssignment> Assignment { get; set; } = new List<ExamAssignment>();
    }
}
