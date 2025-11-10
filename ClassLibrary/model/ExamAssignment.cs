using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.model
{
    public class ExamAssignment
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
