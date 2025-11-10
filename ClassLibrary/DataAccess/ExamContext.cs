using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.model;

namespace ClassLibrary.DataAccess
{
    public class ExamContext :DbContext
    {

        public ExamContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Hold> Hold { get; set; } 
        public DbSet<ExamAssignment> ExamAssignments { get; set; }


    }
}
