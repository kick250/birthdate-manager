using System;

namespace BirthdateManager
{
  namespace Models
  {
    public class People
    {
      private int Id { get; set; }
      private string FirstName { get; set; }
      private string LastName { get; set; }
      private DateTime Birthdate { get; set; }

      public People(int id, string firstName, string lastName, DateTime birthdate)
      {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Birthdate = birthdate;
      }

      public int GetId()
      {
        return Id;
      }

      public string GetFirstName()
      {
        return FirstName;
      }

      public string GetLastName()
      {
        return LastName;
      }

      public string GetFullName()
      {
        return $"{FirstName} {LastName}";
      }

      public DateTime GetBirthdate()
      {
        return Birthdate;
      }
      public string GetFormattedBirthdate(char separateChar = '/')
      {
        return $"{Birthdate.Day}{separateChar}{Birthdate.Month}{separateChar}{Birthdate.Year}";
      }
      public int GetDaysForBirthdate()
      {
        int daysForBirthdate = (GetNextBirthdate() - DateTime.Now).Days;
        return daysForBirthdate;
      }

      public DateTime GetNextBirthdate()
      {
        int currentYear = DateTime.Now.Year;
        DateTime nextBirthdate = new DateTime(currentYear, Birthdate.Month, Birthdate.Day);

        if (DateTime.Now > nextBirthdate)
          return new DateTime(currentYear + 1, Birthdate.Month, Birthdate.Day);

        return nextBirthdate;
      }
    }
  }
}