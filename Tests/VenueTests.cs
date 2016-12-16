using Xunit;
using System;
using System.Collections.Generic;


namespace Tracker
{
  public class VenueTest : IDisposable
  {
    public VenueTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_SaveToDataBase_GetAll()
    {
      List<Venue> allVenues = new List<Venue>{};
      List<Venue> testList = new List<Venue>{};
      Venue newVenue = new Venue("Venue", "Portland");
      testList.Add(newVenue);

      newVenue.Save();
      allVenues = Venue.GetAll();

      Assert.Equal(testList, allVenues);
    }

    public void Dispose()
    {
      Venue.DeleteAll();
    }
  }
}
