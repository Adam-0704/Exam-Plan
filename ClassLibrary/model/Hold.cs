using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.model
{
    public class Hold
    {
        public int Id { get; set; }
        public string HoldId { get; set; }

        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
    }
}
