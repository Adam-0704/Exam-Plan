using ClassLibrary.model;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExamPlan.Pages
{
    public class EmployeeDetailsModel : PageModel
    {
        private readonly IPersonService _personService;

        public EmployeeDetailsModel(IPersonService personService)
        {
            _personService = personService;
        }

        [BindProperty]
        public Person? Employee { get; set; }

        public List<string> RoleOptions { get; set; } = new List<string>
        {
            "Lærer",
            "Censor",
            "Administrator"
        };

        public void OnGet(int id)
        {
            Employee = _personService.GetPersonById(id);
        }

        public IActionResult OnPostUpdate()
        {
            if (!ModelState.IsValid || Employee == null)
            {
                return Page();
            }

            try
            {
                _personService.UpdatePerson(Employee);
                return RedirectToPage("/CreateEmployee");
            }
            catch (Exception)
            {
                Employee = _personService.GetPersonById(Employee.Id);
                return Page();
            }
        }

        public IActionResult OnPostDelete(int deleteId)
        {
            try
            {
                _personService.DeletePerson(deleteId);
                return RedirectToPage("/CreateEmployee");
            }
            catch (Exception)
            {
                Employee = _personService.GetPersonById(deleteId);
                return Page();
            }
        }
    }
}

