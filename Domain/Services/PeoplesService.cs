using System;
using System.Collections.Generic;
using BirthdateManager.Models;
using BirthdateManager.Exceptions;

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

      public static PeoplesService Build()
      {
        return new PeoplesService();
      }

      public List<People> GetAll()
      {
        if (SavedPeoples == null)
          return new List<People> {};

        return SavedPeoples;
      }

      public People GetById(int id)
      {
        if (SavedPeoples == null)
          throw new PeopleNotFoundException();

        People? foundPeople = SavedPeoples.Find(people => people.GetId() == id);

        if (foundPeople == null)
          throw new PeopleNotFoundException();

        return foundPeople;
      }

      public void Update(People people)
      {
        if (SavedPeoples == null)
        {
          SavedPeoples = new List<People> { people };
          return;
        }

        int index = -1;

        for (int i = 0; i < SavedPeoples.Count(); i++)
        {
          if (SavedPeoples[i].GetId() == people.GetId())
          {
            index = i;
            break;
          }
        }

        SavedPeoples[index] = people;
      }

      public void Create(People people)
      {
        if (SavedPeoples == null)
        {
          SavedPeoples = new List<People> {};
          return;
        }

        if (people.IsIdEmpty())
          people.SetId();

        SavedPeoples.Add(people);
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