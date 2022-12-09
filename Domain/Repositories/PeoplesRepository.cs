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
    }
  }
}