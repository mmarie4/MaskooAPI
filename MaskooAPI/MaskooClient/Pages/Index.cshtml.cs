using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaskooAPI.MaskooClient.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {

            // Todo: Check if authenticated and redirect to login page or diary

            string url = "/diary";

            return Redirect(url);
        }
    }
}
