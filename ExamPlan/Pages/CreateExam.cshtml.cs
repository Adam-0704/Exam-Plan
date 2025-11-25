using ClassLibrary.model;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExamPlan.Pages
{
    public class CreateExamModel : PageModel
    {
        private readonly IExamService _examService;
        private readonly IHoldService _holdService;

        public CreateExamModel(IExamService examService, IHoldService holdService)
        {
            _examService = examService;
            _holdService = holdService;
        }

        [BindProperty]
        public Exam CurrentExam { get; set; } = new Exam();

        public List<Exam> AllExams { get; set; } = new List<Exam>();

        public List<Hold> AllHold { get; set; } = new List<Hold>();

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
                return Page();
            }

            try
            {
                _examService.AddExam(CurrentExam);
                Message = "Eksamen oprettet succesfuldt!";
                ModelState.Clear();
                CurrentExam = new Exam();
            }
            catch (Exception ex)
            {
                Message = $"Fejl: {ex.Message}";
            }

            AllExams = _examService.GetAllExams();
            AllHold = _holdService.GetAllHold();
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
            return Page();
        }
    }
}

