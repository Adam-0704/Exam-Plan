using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.model;

namespace ClassLibrary.Services
{
    public interface IPersonService
    {
        List<Person> GetAllPeople();
        Person GetPersonById(int id);
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(int id);
    }
}

