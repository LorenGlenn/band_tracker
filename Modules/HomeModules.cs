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
    }
  }
}
