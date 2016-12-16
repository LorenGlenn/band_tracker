using Xunit;
using System;
using System.Collections.Generic;
using Tracker.Objects;

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

    [Fact]
    public void Test_CheckUpdateVenueInfo_True()
    {
      Venue testVenue = new Venue("Venue", "Portland");
      testVenue.Save();
      int id = testVenue.GetId();
      Venue.Update("Venue", "Seattle", id);
      Venue updated = Venue.Find(id);
      Assert.Equal(updated.GetCity(), "Seattle");
    }

    [Fact]
    public void Test_CheckDeleteVenue_False()
    {
      Venue testVenue = new Venue("Venue", "Portland");
      testVenue.Save();
      List<Venue> result = Venue.GetAll();
      Venue.RemoveAVenue(testVenue.GetId());
      List<Venue> deleted = Venue.GetAll();
      bool isEqual = (result == deleted);
      Assert.Equal(false, isEqual);
    }

    public void Dispose()
    {
      Venue.DeleteAll();
    }
  }
}
