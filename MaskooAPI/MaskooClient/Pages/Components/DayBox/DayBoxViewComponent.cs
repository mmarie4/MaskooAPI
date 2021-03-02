using DAL.Entities.Diaries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MaskooClient.Pages.Components
{
    public class DayBoxViewComponent : ViewComponent
    {

        public DayBoxViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(Day day)
        {
            return View(day);
        }
    }
}
