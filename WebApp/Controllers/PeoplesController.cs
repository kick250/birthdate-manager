using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using BirthdateManager.Services;
using BirthdateManager.Models;
using Requests;

namespace WebApp.Controllers;

public class PeoplesController : Controller
{
  PeoplesService peoplesService = PeoplesService.Build();

  public IActionResult Index()
  {
    List<People> peoples = peoplesService.GetAll();

    return View(peoples);
  }

  public IActionResult Details(int id)
  {
    People people = peoplesService.GetById(id);
    return View(people);
  }

  public IActionResult Edit(int id)
  {
    People people = peoplesService.GetById(id);
    PeopleRequest request = PeopleRequest.BuildFromPeople(people);
    return View(request);
  }

  [HttpPost]
  public IActionResult Update(PeopleRequest peopleRequest)
  {
    if (!ModelState.IsValid)
      return View("edit", peopleRequest);

    People people = peopleRequest.GetDomain();

    peoplesService.Update(people);

    return RedirectToAction("index");
  }
}