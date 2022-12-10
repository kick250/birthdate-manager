using System;
using System.Collections.Generic;
using BirthdateManager.Models;
using BirthdateManager.Exceptions;
using BirthdateManager.Repositories;
using Database.Exceptions;

namespace BirthdateManager
{
  namespace Services
  {
    public class PeoplesService
    {
      private static List<People>? SavedPeoples = new List<People> {
        new People(1, "Breno", "Lobato", new DateTime(2002, 6, 28)),
        new People(2, "Joao", "Silva", new DateTime(2004, 12, 1)),
        new People(3, "Luana", "Silveira", new DateTime(2000, 1, 1)),
      };

      PeoplesRepository Repository { get; set; }

      public static PeoplesService Build()
      {
        return new PeoplesService(
          PeoplesRepository.Build()
        );
      }

      public PeoplesService(PeoplesRepository repository)
      {
        Repository = repository;
      }

      public List<People> GetAll()
      {
        return Repository.GetAll();
      }

      public People GetById(int id)
      {
        try {
          People foundPeople = Repository.GetById(id);

          return foundPeople;
        } catch (RecordNotFound) {
          throw new PeopleNotFoundException();
        }
      }

      public void Update(People people)
      {
        Repository.Update(people);
      }

      public void Create(People people)
      {
        if (SavedPeoples == null)
        {
          SavedPeoples = new List<People> {};
        }

        if (people.IsIdEmpty())
          people.SetId();

        SavedPeoples.Add(people);
      }

      public void DeleteById(int id)
      {
        if (SavedPeoples == null)
        {
          SavedPeoples = new List<People> {};
          return;
        }

        SavedPeoples.RemoveAll(people => people.GetId() == id);
      }

      public List<People> GetByName(string searchedName)
      {
        List<People> peoples = new List<People> {};

        foreach (People people in GetAll())
        {
          string poepleName = people.GetFullName().ToLower();
          if (poepleName.Contains(searchedName.ToLower()))
            peoples.Add(people);
        }
        return peoples;
      }
    }
  }
}