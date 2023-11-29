using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using WebApplicationPA.Pages.Albums;

namespace WebApplicationPA.Pages.Tracks
{
    public class EditModel : PageModel
    {
        public TrackInfo Track = new TrackInfo();
        public string errorMessage = "";
        public string sucessMessage = "";
        public void OnGet()
        {
            String id = Request.Query["id"];

            try
            {
                string connectionString = "Server=localhost;Port=3306;Database=music;Uid=admin;Pwd=Senha13n;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM `tracks` WHERE id_Track = @id";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {

                        command.Parameters.AddWithValue("@id", id);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        
                        {
                            if (reader.Read())
                            {
                             
                                Track.ID = "" + reader.GetInt32(0);
                                Track.trackName = reader.GetString(1);
                                Track.Numero_Track = reader.GetInt32(2).ToString();
  

                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost() 
        {
            String id = Request.Query["album-id"];

            Track.ID = Request.Query["id"];
            Track.trackName = Request.Form["track Name"];
            Track.Numero_Track = Request.Form["Numero_Track"];

            if (Track.trackName.Length == 0 || Track.Numero_Track.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            try
            {
                Console.WriteLine(Track.trackName);
                string connectionString = "Server=localhost;Port=3306;Database=music;Uid=admin;Pwd=Senha13n;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE tracks SET Nome_Track=@tracktitle, Numero_Track=@Numero_Track WHERE id_Track = @id";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@tracktitle", Track.trackName);
                        command.Parameters.AddWithValue("@Numero_Track", Track.Numero_Track);
                        command.Parameters.AddWithValue("@id", Track.ID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/Tracks/Index?album-id=" + id);
        }
    }
}
