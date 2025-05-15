using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index() => View("Index");

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}
//Code corrected and debugged by ClaudeAi
//******************************************************************End Of File******************************************************************
