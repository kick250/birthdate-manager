using System;
using System.ComponentModel.DataAnnotations;
using BirthdateManager.Models;
using Exceptions;

namespace Requests
{
  public class PeopleRequest
  {
    [Required(ErrorMessage = "O id deve ser enviado")]
    public int? Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "O sobrenome é obrigatório.")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "É necessário preencher a data de nascimento.")]
    public DateTime Birthdate { get; set; }

    public static PeopleRequest BuildFromPeople(People people)
    {
      return new PeopleRequest(
        people.GetId(),
        people.GetFirstName(),
        people.GetLastName(),
        people.GetBirthdate()
      );
    }

    public PeopleRequest()
    {

    }

    public PeopleRequest(int id, string firstName, string lastName, DateTime birthdate)
    {
      Id = id;
      FirstName = firstName;
      LastName = lastName;
      Birthdate = birthdate;
    }

    public string GetFormattedBirthdate()
    {
      if (Birthdate == null)
        return "";

      string day = $"{Birthdate.Day}".PadLeft(2, '0');
      string month = $"{Birthdate.Month}".PadLeft(2, '0');

      return $"{Birthdate.Year}-{month}-{day}";
    }

    public People GetDomain()
    {
      if (Id == null || FirstName == null || LastName == null)
        throw new PeopleDataNotPresentException();

      return new People(
        (int) Id,
        FirstName,
        LastName,
        Birthdate
      );
    }
  }
}