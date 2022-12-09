using System;
using System.Data.SqlClient;
using System.Data;
using Database.Exceptions;

namespace Database
{
  public class PeoplesDatabase
  {
    private const string STRINGCONNECTION = @"Server=localhost; Database=birthdate_manager; User Id=SA; Password=123456789Test1";
    private SqlConnection Connection { get; set; }

    public static PeoplesDatabase Build()
    {
      SqlConnection connection = new SqlConnection(STRINGCONNECTION);
      return new PeoplesDatabase(connection);
    }

    public PeoplesDatabase(SqlConnection connection)
    {
      Connection = connection;
    }

    public List<Dictionary<string, string?>> GetAll()
    {
      Connection.Open();

      var command = CreateCommand("select * from peoples;");

      var data = command.ExecuteReader();

      var peoplesData = ParsePeopleColection(data);

      Connection.Close();

      return peoplesData;
    }

    public Dictionary<string, string?> GetById(int id)
    {
      Connection.Open();

      var command = CreateCommand("select * from peoples where id = @ParamId;");

      var param = new SqlParameter("@ParamId", SqlDbType.Int);
      param.Value = id;

      command.Parameters.Add(param);

      var data = command.ExecuteReader();

      if (!data.Read())
        throw new RecordNotFound();

      var peopleData = ParsePeople(data);

      Connection.Close();

      return peopleData;
    }

    private SqlCommand CreateCommand(string query)
    {
      SqlCommand command = Connection.CreateCommand();
      command.CommandText = query;
      command.CommandType = System.Data.CommandType.Text;

      return command;
    }

    private List<Dictionary<string, string?>> ParsePeopleColection(SqlDataReader peoplesData)
    {
      var peoples = new List<Dictionary<string, string?>> {};

      if (peoplesData.HasRows)
      {
        while(peoplesData.Read())
        {
          peoples.Add(ParsePeople(peoplesData));
        }
      }

      return peoples;
    }

    private Dictionary<string, string?> ParsePeople(SqlDataReader peopleData)
    {
      var people = new Dictionary<string, string?> {};

      people.Add("Id", peopleData["id"].ToString());
      people.Add("FirstName", peopleData["first_name"].ToString());
      people.Add("LastName", peopleData["last_name"].ToString());
      people.Add("Birthdate", peopleData["birthdate"].ToString());

      return people;
    }
  }
}