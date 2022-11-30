using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using BirthdateManager.Services;
using BirthdateManager.Models;

namespace WebApp.Controllers;

public class PeoplesController : Controller
{
  PeoplesService peoplesService = PeoplesService.Build();

  public IActionResult Index()
  {
    List<People> peoples = peoplesService.GetAll();

    return View(peoples);
  }
}