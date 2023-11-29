using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using WebApplicationPA.Pages.Albums;

namespace WebApplicationPA.Pages.Tracks
{
     public class DeleteModel : PageModel
    {

        public TrackInfo Track = new TrackInfo();

        void OnGet(){
             try

            {

                String id = Request.Query["id"];

                string connectionString = "Server=localhost;Port=3306;Database=music;Uid=admin;Pwd=Senha13n;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))

                {

                    connection.Open();

                    String sql = "DELETE FROM `Tracks` WHERE id_Tracks = @id";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))

                    {

                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();

                    }

                }

            }

            catch (Exception ex)

            {

            }

            // Response.Redirect("/Albums/Index");
        }

    }
}
