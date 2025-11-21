using ClassLibrary.model;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExamPlan.Pages
{
    public class CreateHoldModel : PageModel
    {
        private readonly IHoldService _holdService;

        public CreateHoldModel(IHoldService holdService)
        {
            _holdService = holdService;
        }

        [BindProperty]
        public Hold CurrentHold { get; set; } = new Hold();

        public List<Hold> AllHold { get; set; } = new List<Hold>();

        public string Message { get; set; } = string.Empty;

        public void OnGet(int? holdid)
        {
            AllHold = _holdService.GetAllHold();
            if (holdid.HasValue)
            { 
                CurrentHold = _holdService.GetHoldById(holdid.Value);
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                AllHold = _holdService.GetAllHold();
                return Page();
            }

            try
            {
                _holdService.AddHold(CurrentHold);
                Message = "Hold oprettet succesfuldt!";
                ModelState.Clear();
                CurrentHold = new Hold();
            }
            catch (Exception ex)
            {
                Message = $"Fejl: {ex.Message}";
            }

            AllHold = _holdService.GetAllHold();
            return Page();
        }
    }
}

