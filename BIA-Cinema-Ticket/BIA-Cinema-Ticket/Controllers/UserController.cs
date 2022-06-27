using BIA_Cinema_Ticket.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BIA_Cinema_Ticket.Controllers
{
    public class UserController : Controller
    {
        
        SqlCommand com = new SqlCommand();
        SqlDataReader userReader;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9DIHVTH;Initial Catalog=BIA;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public static List<User> users = new List<User>();

        public static User currentUser;
        
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(User user)
        {
            try
            {
                String cmd = "Select * from [dbo].[User] where email = '" + user.email + "';";
                User temp = FetchUsers(cmd)[0];

                if (user.password == temp.password)
                {
                    currentUser = temp;
                    
                    if(MovieController.movie != null)
                        return RedirectToAction("MovieDetails", "Movie", new { movie_ID = MovieController.movie.movie_ID });

                    return RedirectToAction("index", "home");
                }
                else
                {
                    ViewBag.errorMassage = "Wrong password!";
                   
                    return View();
                }
            }
            catch
            {
                ViewBag.errorMassage = "Wrong email!";
                return View();
            }



        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Register(User user)
        {
            String cmd = "Select * from [dbo].[User] where email='" + user.email + "' or nickName='" + user.nickName + "';";
            List<User> findUser = FetchUsers(cmd);

            if (findUser.Count != 0)
            {
                ViewBag.errorMassage = "ERROR";
               
                return View();
            }
            else
            {
                string gender;
                if (user.gender) gender = "true";
                else gender = "false";
                cmd = "Insert Into [dbo].[User](name,surname,nickName,gender,email,phoneNumber,birthday,password) values ('" + user.name + "','" + user.surname + "','" + user.nickName + "','" + gender + "','" + user.email + "','" + user.phoneNumber + "','" + user.birthday.ToString("yyyy-MM-dd") + "','" + user.password + "');";
                con.Open();
                com = con.CreateCommand();
                com.CommandType = CommandType.Text;
                com.CommandText = cmd;
                com.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("index", "home");
            }

        }
        public IActionResult SignOut()
        {
            currentUser = null;
            users.Clear();
            return RedirectToAction("index", "home");
        }

        public IActionResult Profile()
        {
            return View();
        }


        public List<User> FetchUsers(String commandText)
        {
            
            try
            {
                con.Open();
                com.Connection = con;

                com.CommandText = commandText;

                userReader = com.ExecuteReader();

                while (userReader.Read())
                {
                    users.Add(new User()
                    {
                        user_ID = (int)userReader["user_ID"],
                        name = userReader["name"].ToString(),
                        surname=userReader["surname"].ToString(),
                        nickName=userReader["nickName"].ToString(),
                        gender=(bool)userReader["gender"],
                        email=userReader["email"].ToString(),
                        phoneNumber=userReader["phoneNumber"].ToString(),
                        birthday=(DateTime)userReader["birthday"],
                        password=userReader["password"].ToString(),
                        userType=(bool)userReader["userType"],

                    }) ;
                }

                con.Close();

                return users;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
       
        public void UpdateCurrentUser()
        {
            User user = currentUser;
            string gender;
            if (user.gender) gender = "true";
            else gender = "false";
            String cmd="Update [dbo].[User] set name='"+user.name+"', surname='"+user.surname+"', gender='"+gender+"', phoneNumber='"+user.phoneNumber+"', birthday='"+ user.birthday.ToString("yyyy-MM-dd") + "', password='"+user.password + "' where user_ID="+user.user_ID+";";
            con.Open();
            com.Connection = con;

            com.CommandText = cmd;

            userReader = com.ExecuteReader();
            con.Close();
        }

        public IActionResult WatchedMoviesPage()
        {
            MovieController movieController = new MovieController();
            String cmd = "SELECT m.* FROM [BIA].[dbo].[WatchedList] w RIGHT JOIN [BIA].[dbo].[Movie] m ON m.movie_ID= w.movie_ID WHERE w.user_ID=" + currentUser.user_ID;
            List<Movie> movies = movieController.FetchMovies(cmd);
            ViewBag.WatchedMoviesPage = movies;

            return View();
        }
        public IActionResult AddFavoriteMovies(String movie_ID)
        {
            MovieController movieController = new MovieController();
            String cmd = "UPDATE w SET isFavorite = 1 FROM[BIA].[dbo].[watchedList] w WHERE w.user_ID=" + currentUser.user_ID + "AND w.movie_ID=" + movie_ID;

            con.Open();
            com = con.CreateCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = cmd;
            com.ExecuteNonQuery();
            con.Close();
            List<Movie> movies = movieController.FetchMovies(cmd);

            ViewBag.AddFavoriteMovies = movies;

            return RedirectToAction("WatchedMoviesPage", "user");
        }


        public IActionResult FavoriteMoviesPage()
        {
            MovieController movieController = new MovieController();
            String cmd = "SELECT m.* FROM [BIA].[dbo].[WatchedList] w RIGHT JOIN [BIA].[dbo].[Movie] m ON m.movie_ID= w.movie_ID WHERE w.user_ID=" + currentUser.user_ID + "AND W.isFavorite=1";
            List<Movie> movies = movieController.FetchMovies(cmd);
            ViewBag.FavoriteMoviesPage = movies;
            return View();
        }
        public IActionResult DeleteFavoriteMovies(String movie_ID)
        {
            MovieController movieController = new MovieController();
            String cmd = "UPDATE w SET isFavorite = 0 FROM[BIA].[dbo].[watchedList] w WHERE w.user_ID =" + currentUser.user_ID + "AND w.movie_ID=" + movie_ID;
            con.Open();
            com = con.CreateCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = cmd;
            com.ExecuteNonQuery();
            con.Close();
            List<Movie> movies = movieController.FetchMovies(cmd);
            ViewBag.DeleteFavoriteMovies = movies;
            return RedirectToAction("FavoriteMoviesPage", "user");
        }
        public IActionResult DeleteUser(int user_ID)
        {

            String cmd = "Delete from[dbo].[User] where user_ID='"+user_ID+"';";
            con.Open();
            com.Connection = con;

            com.CommandText = cmd;

            userReader = com.ExecuteReader();
            con.Close();

            return RedirectToAction("listOfUsers","admin");

        }

        public IActionResult SetAdmin(int user_ID)
        {
            String cmd = "Update [dbo].[User] set userType='True' where user_ID='" + user_ID + "';";

            con.Open();
            com.Connection = con;

            com.CommandText = cmd;

            userReader = com.ExecuteReader();
            con.Close();

            return RedirectToAction("listOfUsers", "admin");
        }

        public IActionResult SetUser(int user_ID)
        {
            String cmd = "Update [dbo].[User] set userType='False' where user_ID='" + user_ID + "';";


            con.Open();
            com.Connection = con;

            com.CommandText = cmd;

            userReader = com.ExecuteReader();
            con.Close();

            return RedirectToAction("listOfUsers", "admin");
        }

        public IActionResult UserTickets()
        {
            string cmd = "Select t.*, c.cinemaName,m.movieName, u.name, u.surname, s.seatLetter, s.seatNo " +
                "from [dbo].[Ticket] t join [dbo].[Cinema] c on t.cinema_ID = c.cinema_ID join [dbo].[Movie] m " +
                "on t.movie_ID=m.movie_ID join [dbo].[User] u on t.user_ID = u.user_ID join [dbo].[Seat] s on " +
                "t.seat_ID = s.seat_ID WHERE t.user_ID = '"+ UserController.currentUser.user_ID +"';";
            TicketController ticketController = new TicketController();
            List<Ticket> tickets = ticketController.FetchTickets(cmd);
            ViewBag.tickets = tickets;
            return View();
        }

        public IActionResult DeleteTicket(int ticket_ID)
        {
            TicketController ticketController = new TicketController();
            ticketController.DeleteTicket(ticket_ID);
            return RedirectToAction("userTickets", "user");
        }

    }
}
