using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.model
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime ExamDate { get; set; }

        public int HoldId { get; set; }
        public Hold Hold { get; set; }

        public ICollection<ExamAssignment> Assignments { get; set; } = new List<ExamAssignment>();
    }
}
