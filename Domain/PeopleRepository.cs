using System;
using BirthdateManager;
using System.Collections.Generic;

namespace BirthdateManager
{
  public class PeopleRepository
  {
    private static List<People>? SavedPeoples = new List<People> {
        new People("Breno", "Lobato", new DateTime(2002, 6, 28)),
        new People("Joao", "Silva", new DateTime(2004, 12, 1)),
        new People("Luana", "Silveira", new DateTime(2000, 1, 1)),
      };

    public List<People> GetAll()
    {
      if (SavedPeoples == null)
        return new List<People> {};

      return SavedPeoples;
    }

    public void Save(People people)
    {
      if (SavedPeoples == null)
      {
        SavedPeoples = new List<People> { people };
        return;
      }

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