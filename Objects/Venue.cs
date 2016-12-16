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
