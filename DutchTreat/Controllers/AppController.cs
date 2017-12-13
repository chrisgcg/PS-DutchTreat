using System.Linq;
using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
  public class AppController : Controller
  {
    private readonly IMailService _mailService;
    private readonly IDutchRepository _repository;

    public AppController(IMailService mailService, IDutchRepository repository)
    {
      _mailService = mailService;
      _repository = repository;
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

    public IActionResult Shop()
    {
      ViewBag.Title = "Shop";
      var prods = _repository.GetAllProducts();

      return View(prods);
    }
  }
}