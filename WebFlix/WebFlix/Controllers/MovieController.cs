using Microsoft.AspNetCore.Mvc;
using WebFlix.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static List<Movies> myMovies = new List<Movies>()
        {
            new Movies() {MovieID = "6710", Title = "Heat", Genre = "action", Certification = "15", ReleaseDate = "12-12-1995", AverageRating = 9},
            new Movies() {MovieID = "6788", Title = "Casino", Genre = "action", Certification = "18", ReleaseDate = "18-06-1995", AverageRating = 9},
            new Movies() {MovieID = "9220", Title = "Spectre", Genre = "action", Certification = "12", ReleaseDate = "10-09-2016", AverageRating = 6},
            new Movies() {MovieID = "2121", Title = "Eden Lake", Genre = "horror", Certification = "18", ReleaseDate = "02-08-2011", AverageRating = 7},
            new Movies() {MovieID = "1467", Title = "Happy Gilmore", Genre = "comedy", Certification = "universal", ReleaseDate = "12-12-1996", AverageRating = 6},
            new Movies() {MovieID = "8954", Title = "Anchorman", Genre = "comedy", Certification = "12", ReleaseDate = "23-06-2006", AverageRating = 8}
        };

        

        


        
        // GET: api/<MovieController>
        
        [HttpGet("GetAllMovies")]
        public IEnumerable<Movies> GetAllMovies()
        {
            return myMovies;
        }

        
         
        // GET api/<MovieController>/5
        [HttpGet("GetByDate")]
        public IActionResult GetByDate()
        {
            var movieByDate = myMovies.OrderByDescending(m=> DateTime.Parse(m.ReleaseDate));
            return Ok(movieByDate);
            
        }

        [HttpGet("GetMovieByID/{movieID}")]
        public IActionResult GetMovieByID(string movieID)
        {
            var movieChoice = myMovies.Where(m => m.MovieID == movieID).Select(m=> new {m.Title}).ToList();
            if(movieChoice.Count > 0)
            {
                return Ok(movieChoice);
            }
            return NotFound();
        }

        [HttpGet("GetByKey/{keyword}")]
        public IActionResult GetByKey(string keyword)
        {
            var titleAndId = myMovies.Where(m => m.Title.Contains(keyword)).Select(m => new { m.MovieID, m.Title }).ToList();
            if(titleAndId.Count > 0)
            {
                return Ok(titleAndId);
            }
            return NotFound($"{keyword} not found in any title!");
        }

        // POST api/<MovieController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
