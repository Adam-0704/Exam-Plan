using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.model;

namespace ClassLibrary.Repository
{
    internal class PersonRepo
    {
        private readonly DataAccess.ExamContext _context;

        public PersonRepo(DataAccess.ExamContext context)
        {
            _context = context;
        }

        public List<Person> GetAll() => _context.People.ToList();

        public void Add(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
        }

        public void Update(Person person)
        {
            _context.People.Update(person);
            _context.SaveChanges();
        }

        public void Delete(Person person)
        {
            _context.People.Remove(person);
            _context.SaveChanges();
        }
    }
}
