using System.Globalization;
using ClassLibrary.model;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExamPlan.Pages
{
    public class CreateEmployeeModel : PageModel
    {
        private readonly IPersonService _personService;

        public CreateEmployeeModel(IPersonService personService)
        {
            _personService = personService;
        }

        [BindProperty]
        public Person CurrentPerson { get; set; } = new Person();

        public List<Person> AllEmployees { get; set; } = new List<Person>();

        public string Message { get; set; } = string.Empty;

        public List<string> RoleOptions { get; set; } = new List<string>
        {
            "Lærer",
            "Intern Censor",
            "Intern Censor",
            "Administrator",
            "EksamensVagt"
        };

        public void OnGet(int? personid)
        {
            AllEmployees = _personService.GetAllPeople();
            if (personid.HasValue)
            { 
                CurrentPerson = _personService.GetPersonById(personid.Value);
            }

            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                AllEmployees = _personService.GetAllPeople();
                return Page();
            }

            try
            {
                _personService.AddPerson(CurrentPerson);
                Message = "Employee added successfully!";
                ModelState.Clear();
                CurrentPerson = new Person();
            }
            catch (Exception ex)
            {
                Message = $"Error: {ex.Message}";
            }

            AllEmployees = _personService.GetAllPeople();
            return Page();
        }
        public IActionResult OnPostDelete(int deleteId)
        {
            try
            {
                _personService.DeletePerson(deleteId);
                Message = "Medarbejder slettet!";
            }
            catch (Exception ex)
            {
                Message = $"Fejl ved sletning: {ex.Message}";
            }

            AllEmployees = _personService.GetAllPeople();
            return Page();
        }
    }
}

