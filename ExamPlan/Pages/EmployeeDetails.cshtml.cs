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

        public Person? Employee { get; set; }

        public void OnGet(int id)
        {
            Employee = _personService.GetPersonById(id);
        }

        public IActionResult OnPost(int deleteId)
        {
            try
            {
                _personService.DeletePerson(deleteId);
                return RedirectToPage("/CreateEmployee");
            }
            catch (Exception ex)
            {
                Employee = _personService.GetPersonById(deleteId);
                return Page();
            }
        }
    }
}

