using System;

namespace BirthdateManager
{
  namespace Models
  {
    public class People
    {
      private int? Id { get; set; }
      private string? FirstName { get; set; }
      private string? LastName { get; set; }
      private DateTime? Birthdate { get; set; }

      public People(int? id, string? firstName, string? lastName, DateTime? birthdate)
      {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Birthdate = birthdate;
      }

      public int? GetId()
      {
        return Id;
      }

      public void SetId()
      {
        Id = DateTime.Now.Second * 3 * DateTime.Now.Millisecond;
      }

      public bool IsIdEmpty()
      {
        return Id == null;
      }

      public string GetFirstName()
      {
        if (FirstName == null)
          return "";

        return FirstName;
      }

      public string GetLastName()
      {
        if (LastName == null)
          return "";

        return LastName;
      }

      public string GetFullName()
      {
        return $"{FirstName} {LastName}";
      }

      public DateTime? GetBirthdate()
      {
        return Birthdate;
      }
      public string GetFormattedBirthdate(char separateChar = '/')
      {
        if (Birthdate == null)
          return "";

        DateTime birthdate = (DateTime) Birthdate;

        return $"{birthdate.Day}{separateChar}{birthdate.Month}{separateChar}{birthdate.Year}";
      }
      public int GetDaysForBirthdate()
      {
        DateTime? nextBirthdateValue = GetNextBirthdate();

        if (nextBirthdateValue == null)
          return -1;

        DateTime nextBirthdate = (DateTime) nextBirthdateValue;

        int daysForBirthdate = (nextBirthdate - DateTime.Now).Days;
        return daysForBirthdate;
      }

      public DateTime? GetNextBirthdate()
      {
        if (Birthdate == null)
          return null;

        DateTime birthdate = (DateTime) Birthdate;

        int currentYear = DateTime.Now.Year;
        DateTime nextBirthdate = new DateTime(currentYear, birthdate.Month, birthdate.Day);

        if (DateTime.Now > nextBirthdate)
          return new DateTime(currentYear + 1, birthdate.Month, birthdate.Day);

        return nextBirthdate;
      }
    }
  }
}