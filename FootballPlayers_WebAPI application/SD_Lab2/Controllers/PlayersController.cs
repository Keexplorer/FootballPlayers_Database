using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SD_Lab2.Models;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace SD_Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly string connectionString;
        public PlayersController(IConfiguration configuration) {
            connectionString = configuration["ConnectionStrings:SqlServerDb"] ?? "";

        }

        [HttpPost]
        public IActionResult CreatePlayer(PlayerDto player)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Players_PersonalInfo " + "(Uniform_Number, Name, Surname, Age, Country) VALUES " +
                        "(@Uniform_Number, @Name, @Surname, @Age, @Country)";

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Uniform_Number", player.Uniform_Number);
                        command.Parameters.AddWithValue("@Name", player.Name);
                        command.Parameters.AddWithValue("@Surname", player.Surname);
                        command.Parameters.AddWithValue("@Age", player.Age);
                        command.Parameters.AddWithValue("@Country", player.Country);

                        command.ExecuteNonQuery();
                    }



                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
            }

            return Ok();
        }

        [HttpGet("PlayerInfo")]
        public IActionResult GetPlayers()
        {
            List<Player> players = new List<Player>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Players_PersonalInfo";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using(var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Player player = new Player();

                                player.Uniform_Number = reader.GetInt32(0);
                                player.Name = reader.GetString(1);
                                player.Surname = reader.GetString(2);
                                player.Age = reader.GetInt32(3);
                                player.Country = reader.GetString(4);
                                players.Add(player);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(players);
        }

        [HttpGet("PlayerPosition")]
        public IActionResult GetPlayers_Position()
        {
            List<Position> position = new List<Position>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Players_Position";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Position position1 = new Position();

                                position1.Uniform_Number = reader.GetInt32(0);
                                position1.Name = reader.GetString(1);
                                position1.Surname = reader.GetString(2);
                                position1.Player_Position = reader.GetString(3);
                                position1.Foot = reader.GetString(4);
                                position.Add(position1);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(position);
        }

        [HttpGet("PlayerValue")]
        public IActionResult GetPlayers_Value()
        {
            List<Value> Pvalue = new List<Value>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Players_Value";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Value value1 = new Value();

                                value1.Uniform_Number = reader.GetInt32(0);
                                value1.Name = reader.GetString(1);
                                value1.Surname = reader.GetString(2);
                                value1.Current_Team = reader.GetString(3);
                                value1.value = reader.GetInt32(4);
                                Pvalue.Add(value1);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(Pvalue);
        }
    }
}
   
