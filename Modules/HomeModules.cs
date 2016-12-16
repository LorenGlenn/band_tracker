using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using Tracker.Objects;

namespace Tracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];

      Get["/bands"] =_=> {
        List<Band> allBands = Band.GetAll();
        return View["bands.cshtml", allBands];
      };

      Get["/venues"] =_=> {
        List<Venue> allVenues = Venue.GetAll();
        return View["venues.cshtml", allVenues];
      };

      Post["/venue-added"] =_=> {
        string name = Request.Form["name"];
        string city = Request.Form["city"];
        Venue newVenue = new Venue(name, city);
        newVenue.Save();
        return View["venue-added.cshtml", name];
      };

      Post["/band-added"] =_=> {
        string name = Request.Form["name"];
        Band newBand = new Band(name);
        newBand.Save();
        return View["band-added.cshtml", name];
      };
    }
  }
}
