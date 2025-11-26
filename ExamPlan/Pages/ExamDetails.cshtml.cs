using ClassLibrary.model;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExamPlan.Pages
{
    public class ExamDetailsModel : PageModel
    {
        private readonly IExamService _examService;
        private readonly IHoldService _holdService;

        public ExamDetailsModel(IExamService examService, IHoldService holdService)
        {
            _examService = examService;
            _holdService = holdService;
        }

        [BindProperty]
        public Exam? Exam { get; set; }

        public List<Hold> AllHold { get; set; } = new List<Hold>();

        public List<string> ExamTypeOptions { get; set; } = new List<string>
        {
            "Mundtlig eksamen",
            "Skriftlig eksamen",
            "Projekt eksamen",
            "Praktisk eksamen",
            "Afgangseksamen",
            "Eksamensprøve"
        };

        public void OnGet(int id)
        {
            Exam = _examService.GetExamById(id);
            AllHold = _holdService.GetAllHold();
        }

        public IActionResult OnPostUpdate()
        {
            if (!ModelState.IsValid || Exam == null)
            {
                Exam = _examService.GetExamById(Exam.Id);
                AllHold = _holdService.GetAllHold();
                return Page();
            }

            try
            {
                _examService.UpdateExam(Exam);
                return RedirectToPage("/CreateExam");
            }
            catch (Exception)
            {
                Exam = _examService.GetExamById(Exam.Id);
                AllHold = _holdService.GetAllHold();
                return Page();
            }
        }

        public IActionResult OnPostDelete(int deleteId)
        {
            try
            {
                _examService.DeleteExam(deleteId);
                return RedirectToPage("/CreateExam");
            }
            catch (Exception)
            {
                Exam = _examService.GetExamById(deleteId);
                AllHold = _holdService.GetAllHold();
                return Page();
            }
        }

    }
}

