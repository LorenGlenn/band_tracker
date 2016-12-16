using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Tracker
{
  public class Venue
  {
    private int _id;
    private string _name;
    private string _city;

    public Venue(string venueName, string venueCity, int id = 0)
    {
      _id = id;
      _name = venueName;
      _city = venueCity;
    }
    public override bool Equals(System.Object otherVenue)
    {

      if (!(otherVenue is Venue))
      {
        return false;
      }
      else
      {
        Venue newVenue = (Venue) otherVenue;
        bool idEquality = (this.GetId() == newVenue.GetId());
        bool nameEquality = (this.GetName() == newVenue.GetName());
        bool cityEquality = (this.GetCity() == newVenue.GetCity());
        return (idEquality && nameEquality && cityEquality);
      }
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public string GetCity()
    {
      return _city;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO venues (name, city) OUTPUT INSERTED.id VALUES (@VenueName, @VenueCity);", conn);

      SqlParameter nameParameter = new SqlParameter("@VenueName", this.GetName());
      SqlParameter cityParameter = new SqlParameter("@VenueCity", this.GetCity());

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(cityParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static List<Venue> GetAll()
    {
      List<Venue> allVenues = new List<Venue>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM venues;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int venueId = rdr.GetInt32(0);
        string venueName = rdr.GetString(1);
        string venueCity = rdr.GetString(2);

        Venue newVenue = new Venue(venueName, venueCity, venueId);
        allVenues.Add(newVenue);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return allVenues;
    }

    public static Venue Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM venues WHERE id = @VenueId;", conn);
      SqlParameter venueIdParameter = new SqlParameter("@VenueId", id.ToString());
      cmd.Parameters.Add(venueIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundVenueId = 0;
      string foundVenueName = null;
      string foundVenueCity = null;
      while(rdr.Read())
      {
        foundVenueId = rdr.GetInt32(0);
        foundVenueName = rdr.GetString(1);
        foundVenueCity = rdr.GetString(2);
      }
      Venue foundVenue = new Venue(foundVenueName, foundVenueCity, foundVenueId);

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return foundVenue;
    }

    public void AddBand(Band newBand)
   {
     SqlConnection conn = DB.Connection();
     conn.Open();

     SqlCommand cmd = new SqlCommand("INSERT INTO bands_venues (band_id, venue_id) VALUES (@BandId, @VenueId);", conn);

     SqlParameter bandIdParameter = new SqlParameter();
     bandIdParameter.ParameterName = "@BandId";
     bandIdParameter.Value = newBand.GetId();
     cmd.Parameters.Add(bandIdParameter);

     SqlParameter venueIdParameter = new SqlParameter();
     venueIdParameter.ParameterName = "@VenueId";
     venueIdParameter.Value = this.GetId();
     cmd.Parameters.Add(venueIdParameter);

     cmd.ExecuteNonQuery();

     if(conn!= null)
     {
       conn.Close();
     }
   }

   public List<Band> GetBands()
  {
    SqlConnection conn = DB.Connection();
    conn.Open();

    SqlCommand cmd = new SqlCommand("SELECT bands.* FROM bands JOIN bands_venues ON (bands_venues.band_id = bands.id) JOIN venues ON (venues.id = bands_venues.venue_id) WHERE venue_id = @VenueId;", conn);
    SqlParameter venueIdParameter = new SqlParameter();
    venueIdParameter.ParameterName = "@VenueId";
    venueIdParameter.Value = this.GetId();
    cmd.Parameters.Add(venueIdParameter);
    SqlDataReader rdr = cmd.ExecuteReader();

    List<Band> allBands = new List<Band> {};
    while(rdr.Read())
    {
      int bandId = rdr.GetInt32(0);
      string bandName = rdr.GetString(1);
      Band newBand = new Band(bandName, bandId);
      allBands.Add(newBand);
    }
    if (rdr != null)
    {
      rdr.Close();
    }

    return allBands;
  }

  public static void Update(string newName, string newCity, int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE venues SET name = @VenueName, city = @VenueCity WHERE id = @VenueId;", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@VenueName";
      nameParameter.Value = newName;

      SqlParameter cityParameter = new SqlParameter();
      cityParameter.ParameterName = "@VenueCity";
      cityParameter.Value = newCity;

      SqlParameter venueIdParameter = new SqlParameter();
      venueIdParameter.ParameterName = "@VenueId";
      venueIdParameter.Value = id.ToString();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(cityParameter);
      cmd.Parameters.Add(venueIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }

    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("Delete FROM venues; DELETE FROM bands_venues;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
