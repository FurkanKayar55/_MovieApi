using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace _MovieApi.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovies _movies;
        private IHostingEnvironment _environment;

        public MoviesController(IMovies movies, IHostingEnvironment environment)
        {
            _movies = movies;
            _environment = environment;
        }

        [HttpGet("{movieId}")]
        [Route("Stats")]
        public IActionResult Stats()
        {
            var item = _movies.GetStats(_environment.WebRootFileProvider.GetFileInfo("files/stats.csv")?.PhysicalPath);
            if (item.FirstOrDefault() == null) return NotFound();
            return Ok(item);
        }
    }
}