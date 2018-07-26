using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Client
  {
    private int _id;
    private string _name;
    private int _stylist_id;

    public Client(string Name, int styleId, int Id = 0)
    {
      _name = Name;
      _id = Id;
      _stylist_id = styleId;
    }
    public int GetClientId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public int GetStylistId()
    {
        return _stylist_id;
    }
    public override int GetHashCode()
    {
      return this.GetClientId().GetHashCode();
    }


    public override bool Equals(System.Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.GetClientId() == newClient.GetClientId());
        bool nameEquality = (this.GetName() == newClient.GetName());
        bool stylistIdEquality = (this.GetClientId() == newClient.GetClientId());
        return(idEquality && nameEquality && stylistIdEquality);
      }
    }


    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (name, stylist_id) VALUES (@name, @stylist_id);";

      cmd.Parameters.Add(new MySqlParameter("@name", _name));
      cmd.Parameters.Add(new MySqlParameter("@stylist_id", _stylist_id));

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }


    public static Client Find(int id)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM clients WHERE id = (@searchId);";

          MySqlParameter searchId = new MySqlParameter();
          searchId.ParameterName = "@searchId";
          searchId.Value = id;
          cmd.Parameters.Add(searchId);

          var rdr = cmd.ExecuteReader() as MySqlDataReader;
          int Id = 0;
          string Name = "";
          int Stylist_id = 0;

          while(rdr.Read())
          {
            Id = rdr.GetInt32(0);
            Name = rdr.GetString(1);
            Stylist_id = rdr.GetInt32(2);
          }
          Client newClient = new Client(Name, Stylist_id, Id);
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          // return new Client("", 0, 0); // make fail
          return newClient; //make pass
        }


    public static List<Client> GetAll()
    {
      List<Client> clientsList = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int Id = rdr.GetInt32(0);
        string Name = rdr.GetString(1);
        int Stylist_id = rdr.GetInt32(2);
        Client newClient = new Client(Name, Stylist_id, Id);

        clientsList.Add(newClient);
      }

      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      //return new List<Client>{};//
      return clientsList;

    }

    public void Edit(string newName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE clients SET Name = @newName WHERE id = @searchId;";

      cmd.Parameters.Add(new MySqlParameter("@searchId", _id));
      cmd.Parameters.Add(new MySqlParameter("@newName", newName));
      //cmd.Parameters.Add(new MySqlParameter("@newStylist_Id", newStylist_Id));

      cmd.ExecuteNonQuery();
      _name = newName;
      //_stylist_Id = newStylist_Id;
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }


    public void Delete()
    {
     MySqlConnection conn = DB.Connection();
     conn.Open();
     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"DELETE FROM clients WHERE id = @thisId;";

     cmd.Parameters.Add(new MySqlParameter("@thisID", _id));

     cmd.ExecuteNonQuery();

     conn.Close();
     if(conn != null)
     {
       conn.Dispose();
     }
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }
  }
}
