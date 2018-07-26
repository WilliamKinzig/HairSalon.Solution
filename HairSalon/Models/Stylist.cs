using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int _id;
    private string _name;
    //private string _details;

    public Stylist(string Name, int Id = 0)
    {
      _name = Name;
      _id = Id;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }


    public override bool Equals(System.Object otherStylist)
    {
      if(!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = (this.GetId() == newStylist.GetId());
        bool nameEquality = (this.GetName() == newStylist.GetName());
        return(idEquality && nameEquality);
      }
    }


    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }


    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (Name) VALUES (@name);";

      cmd.Parameters.Add(new MySqlParameter("@name", _name));

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }


    public static List<Stylist> GetAll()
    {
      List<Stylist> stylistsList = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int Id = rdr.GetInt32(0);
        string Name = rdr.GetString(1);
        Stylist newStylist = new Stylist(Name, Id);
        stylistsList.Add(newStylist);
      }

      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      //return new List<Stylist>{};//fail
      return stylistsList;

    }


    public static Stylist Find(int id)
    {
     MySqlConnection conn = DB.Connection();
     conn.Open();
     var cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"SELECT * FROM stylists WHERE id = (@searchId);";

     MySqlParameter searchId = new MySqlParameter();
     searchId.ParameterName = "@searchId";
     searchId.Value = id;
     cmd.Parameters.Add(searchId);

     var rdr = cmd.ExecuteReader() as MySqlDataReader;
     int StylistId = 0;
     string StylistName = "";

     while(rdr.Read())
     {
       StylistId = rdr.GetInt32(0);
       StylistName = rdr.GetString(1);
     }
     Stylist newStylist = new Stylist(StylistName, StylistId);
     conn.Close();
     if (conn != null)
     {
         conn.Dispose();
     }
     // return new Stylist("", 0); //fail
     return newStylist; //pass
    }

    public void Edit(string newName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylists SET Name = @newName WHERE id = @searchId;";

      cmd.Parameters.Add(new MySqlParameter("@searchId", _id));
      cmd.Parameters.Add(new MySqlParameter("@newName", newName));

      cmd.ExecuteNonQuery();
      _name = newName;

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
      cmd.CommandText = @"DELETE FROM stylists WHERE id = @thisId;";

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
      cmd.CommandText = @"DELETE FROM stylists;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }
  }
}
