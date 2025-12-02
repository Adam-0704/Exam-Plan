using ClassLibrary.model;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExamPlan.Pages
{
    public class SkemaModel : PageModel
    {
        private readonly IPersonService _personService;
        private readonly IExamService _examService;

        public SkemaModel(IPersonService personService, IExamService examService)
        {
            _personService = personService;
            _examService = examService;
        }

        [BindProperty(SupportsGet = true)]
        public int? SelectedPersonId { get; set; }

        public List<Person> AllPersons { get; set; } = new List<Person>();
        public List<Exam> PersonExams { get; set; } = new List<Exam>();
        public Person? SelectedPerson { get; set; }

        public void OnGet()
        {
            AllPersons = _personService.GetAllPeople();

            if (SelectedPersonId.HasValue)
            {
                SelectedPerson = _personService.GetPersonById(SelectedPersonId.Value);
                PersonExams = _examService.GetExamsByPersonId(SelectedPersonId.Value);
            }
        }

        public IActionResult OnPost()
        {
            if (SelectedPersonId.HasValue)
            {
                return RedirectToPage(new { SelectedPersonId = SelectedPersonId.Value });
            }

            AllPersons = _personService.GetAllPeople();
            return Page();
        }
    }
}

