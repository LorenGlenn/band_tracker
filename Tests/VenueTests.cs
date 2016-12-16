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

    [Fact]
    public void Test_GetBandsAssociatedWithVenue()
    {
      List<Band> allBands = new List<Band>{};
      List<Band> testBands = new List<Band>{};

      Venue newVenue = new Venue("Venue", "Seattle");
      newVenue.Save();

      Band newBand = new Band("Band");
      newBand.Save();

      newVenue.AddBand(newBand);
      allBands = newVenue.GetBands();
      testBands.Add(newBand);

      Assert.Equal(testBands, allBands);
    }

    public void Dispose()
    {
      Venue.DeleteAll();
    }
  }
}
