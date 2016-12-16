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
      Get["/add-band"] =_=> View["add-band.cshtml"];
      Get["/add-venue"] =_=> View["add-venue.cshtml"];

      Get["/bands"] =_=> {
        List<Band> allBands = Band.GetAll();
        return View["bands.cshtml", allBands];
      };

      Get["/venues"] =_=> {
        List<Venue> allVenues = Venue.GetAll();
        return View["venues.cshtml", allVenues];
      };

      Get["/band/{id}"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Band selectedBand = Band.Find(parameters.id);
        List<Venue> venues = selectedBand.GetVenues();
        List<Venue> allVenues = Venue.GetAll();
        model.Add("band", selectedBand);
        model.Add("venues", venues);
        model.Add("allVenues", allVenues);
        return View["band.cshtml", model];
      };

      Get["/venue/{id}"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Venue selectedVenue = Venue.Find(parameters.id);
        List<Band> Bands = selectedVenue.GetBands();
        List<Band> allBands = Band.GetAll();
        model.Add("venue", selectedVenue);
        model.Add("bands", Bands);
        model.Add("allBands", allBands);
        return View["venue.cshtml", model];
      };

      Post["/band/associate-venue"] = _ =>
      {
        Band band = Band.Find(Request.Form["band-id"]);
        Venue venue = Venue.Find(Request.Form["venue-id"]);
        band.AddVenue(venue);
        List<Band> allBands = new List<Band>{};
        allBands = Band.GetAll();
        return View["bands.cshtml", allBands];
      };

      Post["/venue/associate-band"] = _ =>
      {
        Venue venue = Venue.Find(Request.Form["venue-id"]);
        Band band = Band.Find(Request.Form["band-id"]);
        venue.AddBand(band);
        List<Venue> allVenues = new List<Venue>{};
        allVenues = Venue.GetAll();
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

      Post["/band-deleted/{id}"] = parameters => {
        Band toDelete = Band.Find(parameters.id);
        string name = toDelete.GetName();
        Band.RemoveABand(parameters.id);
        return View["band-deleted.cshtml", name];
      };

      Post["/venue-deleted/{id}"] = parameters => {
        Venue toDelete = Venue.Find(parameters.id);
        string name = toDelete.GetName();
        Venue.RemoveAVenue(parameters.id);
        return View["venue-deleted.cshtml", name];
      };
    }
  }
}
