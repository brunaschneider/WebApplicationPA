using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace WebApplicationPA.Pages.Albums
{
    public class EditModel : PageModel
    {
        public AlbumInfo Album = new AlbumInfo();
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

                    //Pegando os valores das colunas no banco
                    connection.Open();
                    String sql = "SELECT * FROM `albums` WHERE ID = @id";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Colocando os valores na variável album para o usuario editar
                                Album.ID = "" + reader.GetInt32(0);
                                Album.AlbumName = reader.GetString(1);
                                Album.ArtitsName = reader.GetString(2);
                                Album.Year = "" + reader.GetInt32(3);
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
            Album.ID = Request.Query["id"];
            Album.AlbumName = Request.Form["Album Name"];
            Album.ArtitsName = Request.Form["Artist Name"];
            Album.Year = Request.Form["Year"];

            if (Album.AlbumName.Length == 0 || Album.ArtitsName.Length == 0
                || Album.Year.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            //Inserir

            try
            {
                string connectionString = "Server=localhost;Port=3306;Database=music;Uid=admin;Pwd=Senha13n;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE albums SET Nome_Album=@albumtitle , Nome_Artista=@artist, Ano=@year WHERE albums.ID = @id";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@albumtitle", Album.AlbumName);
                        command.Parameters.AddWithValue("@artist", Album.ArtitsName);
                        command.Parameters.AddWithValue("@year", Album.Year);
                        command.Parameters.AddWithValue("@id", Album.ID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/Albums/Index");
        }
    }
}
