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
        Repository.Create(people);
      }

      public void DeleteById(int id)
      {
        Repository.DeleteById(id);
      }

      public List<People> GetByName(string searchedName)
      {
        return Repository.GetByName(searchedName);
      }
    }
  }
}