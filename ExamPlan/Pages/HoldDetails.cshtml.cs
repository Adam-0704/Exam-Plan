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

        public Hold? Hold { get; set; }

        public void OnGet(int id)
        {
            Hold = _holdService.GetHoldById(id);
        }

    }
}

