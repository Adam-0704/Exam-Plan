using ClassLibrary.model;
using ClassLibrary.Services;
using ClassLibrary.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace ExamPlan.Pages
{
    public class CreateExamModel : PageModel
    {
        private readonly IExamService _examService;
        private readonly IHoldService _holdService;
        private readonly IPersonService _personService;
        private readonly ExamContext _context;

        public CreateExamModel(IExamService examService, IHoldService holdService, IPersonService personService, ExamContext context)
        {
            _examService = examService;
            _holdService = holdService;
            _personService = personService;
            _context = context;
        }

        [BindProperty]
        public Exam CurrentExam { get; set; } = new Exam();

        [BindProperty]
        public List<int> SelectedPersonIds { get; set; } = new List<int>();

        public List<Exam> AllExams { get; set; } = new List<Exam>();

        public List<Hold> AllHold { get; set; } = new List<Hold>();

        public List<Person> AllPersons { get; set; } = new List<Person>();

        public string Message { get; set; } = string.Empty;

        public List<string> ExamTypeOptions { get; set; } = new List<string>
        {
            "Mundtlig eksamen",
            "Skriftlig eksamen",
            "Projekt eksamen",
            "Praktisk eksamen",
            "Afgangseksamen",
            "Eksamensprøve"
        };

        public void OnGet(int? examid)
        {
            AllExams = _examService.GetAllExams();
            AllHold = _holdService.GetAllHold();
            AllPersons = _personService.GetAllPeople();
            if (examid.HasValue)
            { 
                CurrentExam = _examService.GetExamById(examid.Value);
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                AllExams = _examService.GetAllExams();
                AllHold = _holdService.GetAllHold();
                AllPersons = _personService.GetAllPeople();
                return Page();
            }

            try
            {
                var savedExam = _examService.AddExam(CurrentExam);
                
                // Add selected persons to exam
                if (SelectedPersonIds != null && SelectedPersonIds.Any() && savedExam.Id > 0)
                {
                    foreach (var personId in SelectedPersonIds)
                    {
                        var assignment = new ExamAssignment
                        {
                            ExamId = savedExam.Id,
                            PersonId = personId
                        };
                        _context.ExamAssignments.Add(assignment);
                    }
                    _context.SaveChanges();
                }
                
                Message = "Eksamen oprettet succesfuldt!";
                ModelState.Clear();
                CurrentExam = new Exam();
                SelectedPersonIds = new List<int>();
            }
            catch (Exception ex)
            {
                Message = $"Fejl: {ex.Message}";
            }

            AllExams = _examService.GetAllExams();
            AllHold = _holdService.GetAllHold();
            AllPersons = _personService.GetAllPeople();
            return Page();
        }

        public IActionResult OnPostDelete(int deleteId)
        {
            try
            {
                _examService.DeleteExam(deleteId);
                Message = "Eksamen slettet!";
            }
            catch (Exception ex)
            {
                Message = $"Fejl ved sletning: {ex.Message}";
            }

            AllExams = _examService.GetAllExams();
            AllHold = _holdService.GetAllHold();
            AllPersons = _personService.GetAllPeople();
            return Page();
        }
    }
}

