using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.model;
using ClassLibrary.Repository;

namespace ClassLibrary.Services
{
    public class PersonService : IPersonService
    {
        private readonly PersonRepo _personRepo;

        public PersonService(PersonRepo personRepo)
        {
            _personRepo = personRepo;
        }

        public List<Person> GetAllPeople()
        {
            return _personRepo.GetAll();
        }

        public Person GetPersonById(int id)
        {
            var people = _personRepo.GetAll();
            return people.FirstOrDefault(p => p.Id == id);
        }

        public void AddPerson(Person person)
        {
            if (string.IsNullOrWhiteSpace(person.Name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            _personRepo.Add(person);
        }

        public void UpdatePerson(Person person)
        {
            if (string.IsNullOrWhiteSpace(person.Name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            _personRepo.Update(person);
        }

        public void DeletePerson(int id)
        {
            var person = GetPersonById(id);
            if (person != null)
            {
                _personRepo.Delete(person);
            }
        }
    }
}

