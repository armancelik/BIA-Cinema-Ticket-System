using BIA_Cinema_Ticket.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BIA_Cinema_Ticket.Controllers
{
    public class MovieController : Controller
    {
        public static SqlCommand com = new SqlCommand();
        public static SqlDataReader movieReader;

        public static SqlConnection connection = new SqlConnection(@"Data Source=PARTTIME01-PC\INSTANCE2019;Initial Catalog=BIA;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public static Movie movie;
        public List<Movie> FetchMovies(String commandText)
        {
            try
            {
                connection.Open();
                com.Connection = connection;

                com.CommandText = "select AVG(point) as rate, r.movie_ID from MovieRate r join Movie m " +
                    "on r.movie_ID = m.movie_ID" +
                    " group by r.movie_ID " +
                    "order by r.movie_ID, rate";

                SqlDataReader rateReader = com.ExecuteReader();

                Hashtable rates = new Hashtable();

                while (rateReader.Read())
                {
                    rates.Add(rateReader["movie_ID"], rateReader["rate"]);
                }
                connection.Close();

                connection.Open();

                com.Connection = connection;
                com.CommandText = "select movie_ID, categoryName from Category c join CategoriesOfMovies m " +
                                        "on m.category_ID = c.category_ID";
                SqlDataReader categoryReader = com.ExecuteReader();

                Hashtable categories = new Hashtable();


                while (categoryReader.Read())
                {
                    int movieID = (int)categoryReader["movie_ID"];

                    if (categories.ContainsKey(movieID))
                    {
                        ArrayList l = (ArrayList)categories[movieID];
                        l.Add(categoryReader["categoryName"]);
                    }
                    else
                    {
                        ArrayList l = new ArrayList();
                        l.Add(categoryReader["categoryName"]);
                        categories.Add(movieID, l);
                    }
                }
                connection.Close();

                connection.Open();
                
                com.CommandText = commandText;
                movieReader = com.ExecuteReader();

                List <Movie> movies = new List<Movie>();
                while (movieReader.Read())
                {
                    int movieID = (int)movieReader["movie_ID"];

                    int r = rates.ContainsKey(movieID) ? (int)rates[movieID] : 0;

                    string category = "";

                    ArrayList list = (ArrayList)categories[movieID];
                    foreach(String s in list)
                    {
                        category += s+" ";
                    }

                    movies.Add(new Movie()
                    {
                        movie_ID = movieID,
                        description = movieReader["description"].ToString(),
                        duration = (int)movieReader["duration"],
                        movieName = movieReader["movieName"].ToString(),
                        viewStatus = movieReader["viewStatus"].ToString(),
                        trailerLink = movieReader["trailerLink"].ToString(),
                        director = movieReader["director"].ToString(),
                        year = (int)movieReader["year"],
                        categories = category,
                        rate = r
                    });
                }

                connection.Close();
                return movies;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Route("movie/MovieIndex/{category_Name?}")] //linkleri yönlendirmeyi sağlar
        public IActionResult MoviesIndex(string category_Name)
        {
            String cmd2;
            List<Movie> movies = new List<Movie>();
            if (category_Name == null)
            {
                cmd2 = "SELECT TOP 36 * FROM[BIA].[dbo].[Movie]";
                movies = FetchMovies(cmd2);
                ViewBag.allMovies = movies;
            }
            else
            {
                cmd2 = "SELECT * FROM[BIA].[dbo].[Movie]";

                foreach (Movie movie in FetchMovies(cmd2))
                {
                    if (movie.categories.Contains(category_Name))
                    {
                        movies.Add(movie);
                    }
                }

                ViewBag.allMovies = movies;
            }
            cmd2 = "SELECT * FROM[BIA].[dbo].[Movie] where viewStatus = 'in the vision'";
            movies = FetchMovies(cmd2);
            ViewBag.inTheaters = movies;
            cmd2 = "SELECT * FROM[BIA].[dbo].[Movie] where viewStatus = 'coming soon'";
            movies = FetchMovies(cmd2);
            ViewBag.comingSoon = movies;
            cmd2 = "SELECT * FROM[BIA].[dbo].[Movie] where viewStatus = 'old movie'";
            movies = FetchMovies(cmd2);
            ViewBag.oldMovies = movies;

            cmd2 = "SELECT TOP 12 Movie.* FROM [BIA].[dbo].[WatchedList] RIGHT JOIN [BIA].[dbo].[Movie] ON Movie.movie_ID= WatchedList.movie_ID GROUP BY WatchedList.movie_ID,Movie.movie_ID,Movie.description,Movie.duration,Movie.movieName,Movie.viewStatus,Movie.trailerLink,Movie.director,Movie.year ORDER BY COUNT(WatchedList.movie_ID) desc";
            movies = FetchMovies(cmd2);
            ViewBag.TheMostWatching = movies;

            ViewBag.CategoryNames = getCategories();

            return View();
        }
        public List<Review> FetchComments(String commandText)
        {
            SqlCommand secondCommand = new SqlCommand();

            SqlConnection secondConnection = new SqlConnection(@"Data Source=PARTTIME01-PC\INSTANCE2019;Initial Catalog=BIA;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            List<Review> comments = new List<Review>();
            try
            {
                connection.Open();
                com.Connection = connection;
                com.CommandText = commandText;

                movieReader = com.ExecuteReader();

                while (movieReader.Read())
                {
                    int user_ID = (int)movieReader["user_ID"];

                    SqlDataReader reader;

                    secondConnection.Open();
                    secondCommand.Connection = secondConnection;
                    secondCommand.CommandText = "SELECT nickName FROM [BIA].[dbo].[User] WHERE user_ID = " + user_ID;

                    reader = secondCommand.ExecuteReader();
                    String nickName = "";
                    if(reader.Read())
                        nickName = reader["nickName"].ToString();
                    secondConnection.Close();

                    comments.Add(new Review()
                    {
                        commentText = movieReader["commentText"].ToString(),
                        isSpoiler = (bool)movieReader["isSpoiler"],
                        user_ID = user_ID,
                        movie_ID = (int)movieReader["movie_ID"],
                        comment_ID = (int)movieReader["comment_ID"],
                        nickName = nickName,
                    });
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            connection.Close();

            return comments;
        }
        public List<Review> FetchRates(String commandText)
        {
            SqlCommand secondCommand = new SqlCommand();

            SqlConnection secondConnection = new SqlConnection(@"Data Source=PARTTIME01-PC\INSTANCE2019;Initial Catalog=BIA;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            List<Review> rates = new List<Review>();
            try
            {
                connection.Open();
                com.Connection = connection;
                com.CommandText = commandText;

                movieReader = com.ExecuteReader();

                while (movieReader.Read())
                {
                    int user_ID = (int)movieReader["user_ID"];

                    SqlDataReader reader;

                    secondConnection.Open();
                    secondCommand.Connection = secondConnection;
                    secondCommand.CommandText = "SELECT nickName FROM [BIA].[dbo].[User] WHERE user_ID = " + user_ID;

                    reader = secondCommand.ExecuteReader();
                    String nickName = "";
                    if (reader.Read())
                        nickName = reader["nickName"].ToString();

                    rates.Add(new Review()
                    {
                        user_ID = user_ID,
                        nickName = nickName,
                        rate = (int)movieReader["point"]
                    });

                    secondConnection.Close();
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            connection.Close();

            return rates;
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="movie_ID "></param>
        /// <returns></returns>
        public IActionResult MovieDetails(int movie_ID)
        {
            String query = "SELECT * FROM [BIA].[dbo].[Movie] WHERE movie_ID = " + movie_ID;
            movie = FetchMovies(query).ToArray().ElementAt(0);
            
            ViewBag.movie = movie;

            query = "SELECT * FROM [BIA].[dbo].[Comment] WHERE movie_ID = " + movie_ID;
            List<Review> comments = FetchComments(query);
            ViewBag.comments = comments;

            query = "SELECT * FROM [BIA].[dbo].[MovieRate] WHERE movie_ID = " + movie_ID;
            List<Review> rates = FetchRates(query);
            ViewBag.rates = rates;

            if (UserController.currentUser != null)
            {
                query = "SELECT * FROM [BIA].[dbo].[WatchedList] WHERE movie_ID = '" + movie_ID + "' and user_ID = '" + UserController.currentUser.user_ID + "';";

                connection.Open();
                com.Connection = connection;
                com.CommandText = query;
                movieReader = com.ExecuteReader();

                if(movieReader.Read())
                    ViewBag.watched = true;
                else
                    ViewBag.watched = false;

                connection.Close();
            }
            else
                ViewBag.watched = true;

            return View();
        }

        public static List<string> getCategories()
        {
            List<string> list = new List<string>();

            connection.Open();

            com.Connection = connection;
            com.CommandText = "select categoryName from Category";
            SqlDataReader categoryReader = com.ExecuteReader();

            while (categoryReader.Read())
                list.Add(categoryReader["categoryName"].ToString());

            connection.Close();
            
            return list;
        }

        public int getCategoryID(String categoryName)
        {
            connection.Open();

            com.Connection = connection;
            com.CommandText = "select * from Category";
            SqlDataReader categoryReader = com.ExecuteReader();

            while (categoryReader.Read())
            {
                if (categoryReader["categoryName"].ToString().Trim().ToLower() == categoryName.ToLower().Trim())
                {
                    int value= (int)categoryReader["category_ID"];
                    connection.Close();
                    return value;
                }
            }
            connection.Close();

            return -1;
        }

        public int getMovieID(String movieName)
        {
            connection.Open();

            com.Connection = connection;
            com.CommandText = "select * from Movie";
            SqlDataReader categoryReader = com.ExecuteReader();

            while (categoryReader.Read())
            {
                if (categoryReader["movieName"].ToString().Trim().ToLower() == movieName.ToLower().Trim())
                {
                    int value = (int)categoryReader["movie_ID"];
                    connection.Close();
                    return value;
                }
            }
            connection.Close();

            return -1;
        }

        public void AddMovie(Movie movie)
        {
            String query = "Insert into [dbo].[Movie] (description,duration,movieName,viewStatus,trailerLink,director,year) values ('"+movie.description.Replace('\'','"')+"','"+ movie.duration + "','" + movie.movieName + "','" + movie.viewStatus + "','" + movie.trailerLink + "','" + movie.director + "','" + movie.year + "');";

            connection.Open();
            com.Connection = connection;
            com.CommandText = query;
            movieReader = com.ExecuteReader();
            connection.Close();

            query = "Insert into [dbo].[CategoriesOfMovies] (category_ID,movie_ID) values ('"+getCategoryID(movie.categories)+"','"+getMovieID(movie.movieName)+"');";
            connection.Open();
            com.Connection = connection;
            com.CommandText = query;
            movieReader = com.ExecuteReader();
            connection.Close();
        }

        public void UpdateMovie(Movie movie)
        {
            String query = "Update [dbo].[Movie] set description='"+movie.description.Replace('\'','"')+"',duration='"+movie.duration+ "',movieName='"+movie.movieName+"',viewStatus='"+movie.viewStatus+"',trailerLink='"+movie.trailerLink+"',director='"+movie.director+"',year='"+movie.year+"'where movie_ID='"+movie.movie_ID+"';";
            connection.Open();
            com.Connection = connection;
            com.CommandText = query;
            movieReader = com.ExecuteReader();
            connection.Close();

            query = "Delete from [dbo].[CategoriesOfMovies] where movie_ID='"+movie.movie_ID+"';";
            connection.Open();
            com.Connection = connection;
            com.CommandText = query;
            movieReader = com.ExecuteReader();
            connection.Close();

            query = "Insert into [dbo].[CategoriesOfMovies] (category_ID,movie_ID) values ('" + getCategoryID(movie.categories) + "','" + getMovieID(movie.movieName) + "');";
            connection.Open();
            com.Connection = connection;
            com.CommandText = query;
            movieReader = com.ExecuteReader();
            connection.Close();
        }

        public void DeleteMovie(int movie_ID)
        {
            String query = "Delete from [dbo].[Movie] where movie_ID='" + movie_ID + "';";
            connection.Open();
            com.Connection = connection;
            com.CommandText = query;
            movieReader = com.ExecuteReader();
            connection.Close();

            query = "Delete from [dbo].[CategoriesOfMovies] where movie_ID='" +movie_ID + "';";
            connection.Open();
            com.Connection = connection;
            com.CommandText = query;
            movieReader = com.ExecuteReader();
            connection.Close();
        }
        [HttpPost]
        public IActionResult makeComment(Review review)
        {
            string cmd = "Insert Into [dbo].[Comment](commentText,isSpoiler," +
                "movie_ID,user_ID) values ('" + review.commentText + "','" + (review.isSpoiler ? "true" : "false") +
                "','" + movie.movie_ID + "','" + UserController.currentUser.user_ID + "');";
            connection.Open();
            com = connection.CreateCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = cmd;
            com.ExecuteNonQuery();
            connection.Close();

            return RedirectToAction("MovieDetails", "Movie", new { movie_ID = movie.movie_ID });
        }

        [HttpPost]
        public IActionResult rate(Review review)
        {
            string cmd = "Select * from [dbo].[MovieRate] where movie_ID = '" + movie.movie_ID +
                "' and user_ID = '" + UserController.currentUser.user_ID + "';";

            connection.Open();
            com.Connection = connection;
            com.CommandText = cmd;
            movieReader = com.ExecuteReader();
            if (movieReader.Read())
            {
                connection.Close();
                return RedirectToAction("MovieDetails", "Movie", new { movie_ID = movie.movie_ID });
            }
            connection.Close();

            cmd = "Insert Into [dbo].[MovieRate](point,movie_ID,user_ID) values ('" +
                review.rate + "','" + movie.movie_ID + "','" + UserController.currentUser.user_ID + "');";
            connection.Open();
            com = connection.CreateCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = cmd;
            com.ExecuteNonQuery();
            connection.Close();

            return RedirectToAction("MovieDetails", "Movie", new { movie_ID = movie.movie_ID });
        }
    }
}
