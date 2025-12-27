using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimWeb.Pages;

public class IndexModel : PageModel
{
    public string Moves { get; private set; } = "";

    public void OnGet()
    {
        Moves = "dlrludluddlrlur";
    }
}
