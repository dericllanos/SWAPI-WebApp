using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SWAPIWebApp_IntelliQ.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SWAPIWebApp_IntelliQ.Controllers
{
    public class DetailsController : Controller
    {
        public async Task<ActionResult> Details(string Url)
        {
            Person people = new Person();
            Planet homeworld = new Planet();
            Film films = new Film();
            Species species = new Species();
            Vehicle vehicles = new Vehicle();
            Starship starships = new Starship();

            List<string> titles = new List<string>();
            List<string> speciesNames = new List<string>();
            List<string> vehicleNames = new List<string>();
            List<string> starshipNames = new List<string>();

            dynamic mymodel = new ExpandoObject();

            using (HttpClient client = new HttpClient())
            {
                // People
                HttpResponseMessage peopleRes = await client.GetAsync(Url);
                if (peopleRes.IsSuccessStatusCode)
                {
                    string response = await peopleRes.Content.ReadAsStringAsync();
                    people = JsonConvert.DeserializeObject<Person>(response);

                    if (people.Name.Count() <= 0)
                    {
                        ViewBag.Message = "Error Retrieving People";
                    }

                    mymodel.People = people;
                }

                // Homeworld
                HttpResponseMessage homeRes = await client.GetAsync(people.Homeworld);
                if (homeRes.IsSuccessStatusCode)
                {
                    string response = await homeRes.Content.ReadAsStringAsync();
                    homeworld = JsonConvert.DeserializeObject<Planet>(response);
                    mymodel.Homeworld = homeworld;
                }

                // Films
                foreach (var item in people.Films)
                {
                    HttpResponseMessage filmsRes = await client.GetAsync(item);
                    if (filmsRes.IsSuccessStatusCode)
                    {
                        string response = await filmsRes.Content.ReadAsStringAsync();
                        films = JsonConvert.DeserializeObject<Film>(response);
                        titles.Add($"Ep. {films.EpisodeId} - {films.Title}");
                        mymodel.Films = titles;
                    }
                }

                // Species
                if (people.Species.Count() <= 0)
                {
                    speciesNames.Add("Human");
                    mymodel.Species = speciesNames;
                }
                else
                {
                    foreach (var item in people.Species)
                    {
                        HttpResponseMessage specRes = await client.GetAsync(item);
                        if (specRes.IsSuccessStatusCode)
                        {
                            string response = await specRes.Content.ReadAsStringAsync();
                            species = JsonConvert.DeserializeObject<Species>(response);
                            speciesNames.Add(species.Name);
                            mymodel.Species = speciesNames;
                        }
                    }    
                }

                // Vehicles
                if (people.Vehicles.Count() <= 0)
                {
                    vehicleNames.Add("None");
                    mymodel.Vehicles = vehicleNames;
                }
                else
                {
                    foreach (var item in people.Vehicles)
                    {
                        HttpResponseMessage vecRes = await client.GetAsync(item);
                        if (vecRes.IsSuccessStatusCode)
                        {
                            string response = await vecRes.Content.ReadAsStringAsync();
                            vehicles = JsonConvert.DeserializeObject<Vehicle>(response);
                            vehicleNames.Add(vehicles.Name);
                        }
                    }
                    mymodel.Vehicles = vehicleNames;
                }

                // Starships
                if (people.Starships.Count() <= 0)
                {
                    starshipNames.Add("None");
                    mymodel.Starships = starshipNames;
                }
                else
                {
                    foreach (var item in people.Starships)
                    {
                        HttpResponseMessage starRes = await client.GetAsync(item);
                        if (starRes.IsSuccessStatusCode)
                        {
                            string response = await starRes.Content.ReadAsStringAsync();
                            starships = JsonConvert.DeserializeObject<Starship>(response);
                            starshipNames.Add(starships.Name);
                        }
                    }
                    mymodel.Starships = starshipNames;
                }

                return View(mymodel);
            }
        }
    }
}