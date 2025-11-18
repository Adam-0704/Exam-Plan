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
        public Person NewPerson { get; set; } = new Person();

        public List<Person> AllEmployees { get; set; } = new List<Person>();

        public string Message { get; set; } = string.Empty;

        public List<string> RoleOptions { get; set; } = new List<string>
        {
            "Lærer",
            "Censor",
            "Administrator"
        };

        public void OnGet()
        {
            AllEmployees = _personService.GetAllPeople();
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
                _personService.AddPerson(NewPerson);
                Message = "Employee added successfully!";
                ModelState.Clear();
                NewPerson = new Person();
            }
            catch (Exception ex)
            {
                Message = $"Error: {ex.Message}";
            }

            AllEmployees = _personService.GetAllPeople();
            return Page();
        }
    }
}

