using System;
using WebFlix.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WebFlixClient
{

    class Client
    {
        static async Task RequestMovies()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7061/");

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // GET: api/GetAllMovies
                    HttpResponseMessage response = await client.GetAsync("/api/Movie/GetAllMovies");
                    if (response.IsSuccessStatusCode)
                    {
                        var allMovies = await response.Content.ReadFromJsonAsync<IEnumerable<Movies>>();
                        foreach (var movie in allMovies)
                        {
                            Console.WriteLine(movie);
                            Console.WriteLine("************************");
                                
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                    // GET: api/movies/GetByDate
                    response = await client.GetAsync("/api/Movie/GetByDate");
                    if (response.IsSuccessStatusCode) {

                        var movieDate = await response.Content.ReadFromJsonAsync<IEnumerable<Movies>>();
                        foreach(var date in movieDate)
                        {
                            Console.WriteLine("                 ");
                            Console.WriteLine(date.ReleaseDate.ToString());
                            Console.WriteLine("*************");
                            Console.WriteLine("              ");
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                    //GET api/movies/GetMovieByID
                    
                    string movieID = "6710";
                    string apiURL = "/api/Movie/GetMovieByID/{0}";
                    string url = string.Format(apiURL, movieID);
                    response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var myMovie = await response.Content.ReadFromJsonAsync<IEnumerable<Movies>>();
                        foreach(var movie in myMovie)
                        {
                            Console.WriteLine(movie.MovieID + movie.Title);
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                        
                         
                    
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public static void Main()
        {
            RequestMovies().Wait();
        }
    }

}