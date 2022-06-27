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
    public class TicketController : Controller
    {
        public static List<Ticket> tickets = new List<Ticket>();

        public static Ticket tempTicket = new Ticket();
        public static List<int> takenSeats = new List<int>();
        public static List<int> choosenSeats = new List<int>();

        SqlCommand com = new SqlCommand();
        SqlDataReader dataReader;

        SqlConnection connection = new SqlConnection(@"Data Source=PHOENIX;Initial Catalog=BIA;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public List<Ticket> FetchTickets(String commandText)
        {
            List<Ticket> tickets = new List<Ticket>();

            try
            {
                connection.Open();
                com.Connection = connection;
                com.CommandText = commandText;
                dataReader = com.ExecuteReader();

                while (dataReader.Read())
                {
                    tickets.Add(new Ticket()
                    {
                        ticket_ID = (int)dataReader["ticket_ID"],
                        movie_ID = (int)dataReader["movie_ID"],
                        cinema_ID = (int)dataReader["cinema_ID"],
                        seat_ID = (int)dataReader["seat_ID"],
                        seatNo = (int)dataReader["seatNo"],
                        seatLetter = dataReader["seatLetter"].ToString(),
                        user_ID = (int)dataReader["user_ID"],
                        date = (DateTime)dataReader["date"],
                        session = dataReader["session"].ToString(),
                        cardOwnerName = dataReader["cardOwnerName"].ToString(),
                        cardNumber = dataReader["cardNumber"].ToString(),
                        cardValidDate = dataReader["cardValidDate"].ToString(),
                        cardCVV = dataReader["cardCVV"].ToString(),
                        price = (int)dataReader["price"],
                        cinemaName=dataReader["cinemaName"].ToString(),
                        movieName=dataReader["movieName"].ToString(),
                        name=dataReader["name"].ToString(),
                        surname=dataReader["surname"].ToString()
                    });
                }

                connection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            

            return tickets;
        }
        public List<Cinema> FetchCinemas(String commandText)
        {
            List<Cinema> cinemas = new List<Cinema>();

            try
            {
                connection.Open();
                com.Connection = connection;
                com.CommandText = commandText;

                dataReader = com.ExecuteReader();

                while (dataReader.Read())
                {
                    cinemas.Add(new Cinema()
                    {
                        cinema_ID = (int)dataReader["cinema_ID"],
                        cinemaName = dataReader["cinemaName"].ToString(),
                        city = dataReader["cityName"].ToString(),
                        addressText = dataReader["addressText"].ToString()
                    });
                }

                connection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return cinemas;
        }
        public IActionResult BuyTicket(int movie_ID)
        {
            if (UserController.currentUser == null)
                return RedirectToAction("login", "user");

            tempTicket.movie_ID = movie_ID;

            String commandText = "SELECT * FROM [BIA].[dbo].[Movie] where movie_ID = " + movie_ID;
            MovieController movieController = new MovieController();

            Movie movie = movieController.FetchMovies(commandText).ToArray().ElementAt(0);
            ViewBag.movieName = movie.movieName;

            commandText = "SELECT cinemaName, addressText, cityName, cinema_ID " +
                "FROM [dbo].[Cinema] c, [dbo].[Address] a, [dbo].[City] ci where c.address_ID = a.address_ID" +
                " and a.city_ID = ci.city_ID";

            List<Cinema> cinemas = FetchCinemas(commandText);
            ViewBag.cinemas = cinemas;

            List<string> cities = new List<string>();

            foreach(Cinema cinema in cinemas)
            {
                if (!cities.Contains(cinema.city))
                    cities.Add(cinema.city);
            }

            ViewBag.cities = cities;

            return View();
        }

        [HttpPost]
        public IActionResult ChooseSeat(Ticket ticket)
        {
            tempTicket.date = ticket.date;
            tempTicket.cinema_ID = ticket.cinema_ID;
            tempTicket.session = ticket.session;

            string commandText = "SELECT * FROM [BIA].[dbo].[Ticket] t " +
                "join [BIA].[dbo].[Seat] s on t.seat_ID = s.seat_ID JOIN [BIA].[dbo].[Cinema] c " +
                "on t.cinema_ID = c.cinema_ID JOIN [BIA].[dbo].[User] u on t.user_ID = u.user_ID " +
                "JOIN [BIA].[dbo].[Movie] m ON t.movie_ID = m.movie_ID WHERE t.movie_ID = " + tempTicket.movie_ID +
                " and t.cinema_ID = " + ticket.cinema_ID + " and t.date = '" + ticket.date.ToString("yyyy'/'MM'/'dd") + 
                "' and t.session = '" + ticket.session + "'";
            List<Ticket> tickets = FetchTickets(commandText);

            takenSeats.Clear();
            foreach (Ticket t in tickets)
            {
                takenSeats.Add(t.seat_ID);
            }

            return View();
        }

        [HttpGet]
        public IActionResult ChooseSeat()
        {
            return View();
        }

        public IActionResult addSeat(int seat_ID)
        {
            choosenSeats.Add(seat_ID);

            return RedirectToAction("ChooseSeat", "Ticket");
        }

        public IActionResult deleteSeat(int seat_ID)
        {
            choosenSeats.Remove(seat_ID);

            return RedirectToAction("ChooseSeat", "Ticket");
        }

        public IActionResult PaymentTicket()
        {
            if(choosenSeats.Count() == 0)
            {
                ViewBag.errorMassage = "Please choose a seat";
                return RedirectToAction("chooseseat","ticket");
            }

            return View();
        }

        [HttpPost]
        public IActionResult saveTicket(Ticket ticket)
        {
            foreach (int seatID in choosenSeats)
            {
                string cmd = "Insert Into [dbo].[Ticket](cinema_ID, movie_ID, user_ID, seat_ID, date, session, cardOwnerName, " +
                    "cardNumber, cardValidDate, cardCVV, price) values ('" + tempTicket.cinema_ID + "','" + tempTicket.movie_ID + "','" + UserController.currentUser.user_ID + 
                    "','" + seatID + "','" + tempTicket.date.ToString("yyyy-MM-dd") + "','" + tempTicket.session + "','" + ticket.cardOwnerName + 
                    "','" + ticket.cardNumber  +"','" + ticket.cardValidDate + "','" + ticket.cardCVV + "','"+ 20 +"');";
                connection.Open();
                com = connection.CreateCommand();
                com.CommandType = CommandType.Text;
                com.CommandText = cmd;
                com.ExecuteNonQuery();
                connection.Close();
            }

            choosenSeats.Clear();

            return RedirectToAction("index", "home");
        }

        public List<Ticket> getAllTickets()
        {
            string cmd = "SELECT * FROM [BIA].[dbo].[Ticket] t " +
                "join [BIA].[dbo].[Seat] s on t.seat_ID = s.seat_ID JOIN [BIA].[dbo].[Cinema] c" +
                "on t.cinema_ID = c.cinema_ID JOIN [BIA].[dbo].[User] u on t.user_ID = u.user_ID";
            List<Ticket>tickets = new TicketController().FetchTickets(cmd);

            return tickets;
        }

        public void DeleteTicket(int ticket_ID)
        {
            String query = "Delete from [dbo].[Ticket] where ticket_ID='" + ticket_ID + "';";
            connection.Open();
            com.Connection = connection;
            com.CommandText = query;
            dataReader = com.ExecuteReader();
            connection.Close();
        }

    }
}
