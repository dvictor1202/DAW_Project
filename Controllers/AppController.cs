using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavShop.Data;
using DavShop.Services;
using DavShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DavShop.Controllers
{
  public class AppController : Controller
  {
    private readonly IMailService _mailService;
    private readonly IDavRepository _repository;

    public AppController(IMailService mailService, IDavRepository repository)
    {
      _mailService = mailService;
      _repository = repository;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpGet("contact")]
    public IActionResult Contact()
    {
      return View();
    }

    [HttpPost("contact")]
    public IActionResult Contact(ContactViewModel model)
    {
      if (ModelState.IsValid)
      {
        // Send the Email
        _mailService.SendMessage("dvictor1202@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
        ViewBag.UserMessage = "Mail Sent...";
        ModelState.Clear();
      }

      return View();
    }

    public IActionResult About()
    {
      return View();
    }

    [Authorize]
    public IActionResult Shop()
    {
      var results = _repository.GetAllProducts();

      return View(results);
    }
  }
}
