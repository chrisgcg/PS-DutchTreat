using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
  public class AppController : Controller
  {
    private readonly IMailService _mailService;

    public AppController(IMailService mailService)
    {
      _mailService = mailService;
    }
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Contact()
    {
      ViewBag.Title = "Contact Us";
      return View();
    }

    [HttpPost]
    public IActionResult Contact(ContactViewModel model)
    {
      if (ModelState.IsValid) { 
        _mailService.SendMessage("chris.phillips80@gmail.com", model.Subject, $"From: {model.Email}, Message: {model.Message}");
        ViewBag.UserMessage = "Mail Sent";
        ModelState.Clear();
      }
      return View();
    }

    public IActionResult About()
    {
      ViewBag.Title = "About Us";
      return View();
    }
  }
}