using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.model;

namespace ClassLibrary.Repository
{
    public class HoldRepo
    {
        private readonly DataAccess.ExamContext _context;

        public HoldRepo(DataAccess.ExamContext context)
        {
            _context = context;
        }

        public List<Hold> GetAll() => _context.Hold.ToList();

        public void Add(Hold hold)
        {
            _context.Hold.Add(hold);
            _context.SaveChanges();
        }

        public void Update(Hold hold)
        {
            _context.Hold.Update(hold);
            _context.SaveChanges();
        }

        public void Delete(Hold hold)
        {
            _context.Hold.Remove(hold);
            _context.SaveChanges();
        }
    }
}
