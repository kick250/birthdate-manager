using System;

namespace BirthdateManager
{
  public class People
  {
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private DateTime Birthdate { get; set; }

    public People(string firstName, string lastName, DateTime birthdate)
    {
      FirstName = firstName;
      LastName = lastName;
      Birthdate = birthdate;
    }

    public string GetFullName()
    {
      return $"{FirstName} {LastName}";
    }

    public string GetFormattedBirthdate()
    {
      return $"{Birthdate.Day}/{Birthdate.Month}/{Birthdate.Year}";
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