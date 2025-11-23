using ClassLibrary.model;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExamPlan.Pages
{
    public class HoldDetailsModel : PageModel
    {
        private readonly IHoldService _holdService;

        public HoldDetailsModel(IHoldService holdService)
        {
            _holdService = holdService;
        }

        [BindProperty]
        public Hold? Hold { get; set; }

        public void OnGet(int id)
        {
            Hold = _holdService.GetHoldById(id);
        }

        public IActionResult OnPostUpdate()
        {
            if (!ModelState.IsValid || Hold == null)
            {
                return Page();
            }

            try
            {
                _holdService.UpdateHold(Hold);
                return RedirectToPage("/CreateHold");
            }
            catch (Exception)
            {
                Hold = _holdService.GetHoldById(Hold.Id);
                return Page();
            }
        }

        public IActionResult OnPostDelete(int deleteId)
        {
            try
            {
                _holdService.DeleteHold(deleteId);
                return RedirectToPage("/CreateHold");
            }
            catch (Exception)
            {
                Hold = _holdService.GetHoldById(deleteId);
                return Page();
            }
        }

    }
}

