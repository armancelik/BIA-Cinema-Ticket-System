using BIA_Cinema_Ticket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace BIA_Cinema_Ticket.Controllers
{
    public class HomeController : Controller
    {
        MovieController movieController = new MovieController();
        public IConfiguration Configuration;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }
        
        public IActionResult Index()
        {
            
            String cmd;
            cmd = "SELECT * FROM[BIA].[dbo].[Movie] where viewStatus = 'in the vision'";
            List<Movie> movies = movieController.FetchMovies(cmd);
            ViewBag.inTheaters = movies;
            cmd = "SELECT * FROM[BIA].[dbo].[Movie] where viewStatus = 'coming soon'";
            movies = movieController.FetchMovies(cmd);
            ViewBag.comingSoon = movies;
            cmd = "SELECT * FROM[BIA].[dbo].[Movie] where viewStatus = 'old movie'";
            movies = movieController.FetchMovies(cmd);
            ViewBag.oldMovies = movies;
            cmd = "SELECT TOP 10  AVG(r.point) as rate, m.movie_ID,m.description,m.duration,m.movieName,m.viewStatus,m.trailerLink,m.director,m.year  FROM[BIA].[dbo].[MovieRate] r RIGHT JOIN [BIA].[dbo].[Movie] m ON r.movie_ID=m.movie_ID GROUP BY m.movie_ID,m.description,m.duration,m.movieName,m.viewStatus,m.trailerLink,m.director,m.year ORDER BY rate desc";
            movies = movieController.FetchMovies(cmd);
            ViewBag.movirate = movies;

            return View();
        }
        [HttpPost]
        public IActionResult Search(String searchWord)
        {
            String cmd = "SELECT * FROM [BIA].[dbo].[Movie] m JOIN [BIA].[dbo].[CategoriesOfMovies] com ON m.movie_ID = com.movie_ID " +
                "JOIN [BIA].[dbo].[Category] c ON com.category_ID = c.category_ID where movieName LIKE '%" + searchWord + "%' OR categoryName LIKE '%" +
                searchWord + "%' OR director LIKE '%" + searchWord +"%' OR description LIKE '%" + searchWord + "%';";
            List<Movie> movies = movieController.FetchMovies(cmd);
            ViewBag.movies = movies;

            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
