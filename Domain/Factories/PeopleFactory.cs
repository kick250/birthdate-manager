using System;
using BirthdateManager.Models;

namespace BirthdateManager
{
  namespace Factories
  {
    public class PeopleFactory
    {
      public People BuildFromDictionary(Dictionary<string, string?> peopleData)
      {
        return new People(
          GetId(peopleData),
          peopleData["FirstName"],
          peopleData["LastName"],
          GetBirthdate(peopleData)
        );
      }

      private int? GetId(Dictionary<string, string?> peopleData)
      {
        int? id;
        string? idValue = peopleData["Id"];

        if (idValue == null)
          id = null;
        else
          id = int.Parse(idValue);

        return id;
      }

      private DateTime? GetBirthdate(Dictionary<string, string?> peopleData)
      {
        DateTime? birthdate;
        string? value = peopleData["Birthdate"];

        if (value == null)
          birthdate = null;
        else
          birthdate = DateTime.Parse(value);

        return birthdate;
      }
    }
  }
}