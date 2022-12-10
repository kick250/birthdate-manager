using System;
using System.Collections.Generic;
using BirthdateManager.Models;
using BirthdateManager.Factories;
using Database;

namespace BirthdateManager
{
  namespace Repositories
  {
    public class PeoplesRepository
    {
      PeoplesDatabase Database { get; set; }
      PeopleFactory Factory { get; set; }

      public static PeoplesRepository Build()
      {
        return new PeoplesRepository(
          PeoplesDatabase.Build(),
          new PeopleFactory()
        );
      }

      public PeoplesRepository(PeoplesDatabase database, PeopleFactory factory)
      {
        Database = database;
        Factory = factory;
      }

      public List<People> GetAll()
      {
        var peoples = new List<People> {};

        foreach(var peopleData in Database.GetAll())
        {
          peoples.Add(
            Factory.BuildFromDictionary(peopleData)
          );
        }

        return peoples;
      }

      public People GetById(int id)
      {
        var peopleData = Database.GetById(id);

        return Factory.BuildFromDictionary(peopleData);
      }

      public void Create(People people)
      {
        Database.Create(people.ToDictionary());
      }

      public void Update(People people)
      {
        Database.Update(people.ToDictionary());
      }

      public void DeleteById(int id)
      {
        Database.DeleteById(id);
      }
    }
  }
}