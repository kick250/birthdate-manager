using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using BirthdateManager.Services;
using BirthdateManager.Models;
using BirthdateManager.Exceptions;
using Requests;

namespace WebApp.Controllers;

public class PeoplesController : Controller
{
  PeoplesService peoplesService = PeoplesService.Build();

  public IActionResult Index()
  {
    List<People> peoples = peoplesService.GetAllOrderedByBirthdate();

    return View(peoples);
  }

  public IActionResult Details(int id)
  {
    People people = peoplesService.GetById(id);
    return View(people);
  }

  public IActionResult Edit(int id)
  {
    try {
      People people = peoplesService.GetById(id);
      PeopleRequest request = PeopleRequest.BuildFromPeople(people);
      return View(request);
    } catch (PeopleNotFoundException) {
      return RedirectToAction("index");
    }
  }

  [HttpPost]
  public IActionResult Update(PeopleRequest peopleRequest)
  {
    if (!ModelState.IsValid)
      return View("edit", peopleRequest);

    peoplesService.Update(peopleRequest.GetDomain());

    return RedirectToAction("index");
  }

  public IActionResult New()
  {
    PeopleRequest peopleRequest = new PeopleRequest();
    return View(peopleRequest);
  }

  public IActionResult Create(PeopleRequest peopleRequest)
  {
    if (!ModelState.IsValid)
      return View("new", peopleRequest);

    peoplesService.Create(peopleRequest.GetDomain());
    return RedirectToAction("index");
  }

  [HttpPost]
  public IActionResult Delete(int id)
  {
    peoplesService.DeleteById(id);

    return RedirectToAction("index");
  }

  public IActionResult Search(string query)
  {
    ViewBag.query = query;

    List<People> peoples = peoplesService.GetByName(query);

    return View(peoples);
  }
}