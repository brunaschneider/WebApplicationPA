using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using WebApplicationPA.Pages.Tracks;

namespace WebApplicationPA.Pages.Albums
{
    public class DeleteModel : PageModel
    {
        public AlbumInfo Album = new AlbumInfo();
        // public string errorMessage = "";
        // public string sucessMessage = "";

        public List<TrackInfo> Tracks = new List<TrackInfo>();
        //Comando para pegar os ids relacionados nas tabelas de albums e tracks
        String delete_item = "select a.* from tracks a join albums b on b.id = a.id_Album where a.id_album = @id";

        public void OnGet()
        {
            String id = Request.Query["id"];
            pegar_Album(id);
            pegar_Tracks(id);
        }


        private void pegar_Album(String id)
        {
            try
            {

                // Pegando o dado de acordo com o ID da linha clicada
                string connectionString = "Server=localhost;Port=3306;Database=music;Uid=admin;Pwd=Senha13n;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {

                    //Pegando os valores das colunas no banco
                    connection.Open();
                    String sql = "SELECT * FROM `albums` WHERE ID = @id";
                    //Permitir comandos
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        //Ler os dados da linha inteira referente ao id selecionado
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                //Atribuindo o valor do banco à variável
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
                // errorMessage = ex.Message;
            }
        }
        private void pegar_Tracks(String id)
        {
            try
            {
                string connectionString = "Server=localhost;Port=3306;Database=music;Uid=admin;Pwd=Senha13n;";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(delete_item, connection);
                    command.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TrackInfo t = new TrackInfo()
                            {
                                ID = "" + reader.GetInt32(0),
                                trackName = reader.GetString(1),
                                Numero_Track = reader.GetInt32(2).ToString(),
                            };
                            Tracks.Add(t);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
            }
        }

        public void OnPost(){
            Console.WriteLine("oi");
            deletar_Tracks();
        }

        void deletar_Tracks()
        {
            try

            {

                String id = Request.Query["id"];



                string connectionString = "Server=localhost;Port=3306;Database=music;Uid=admin;Pwd=Senha13n;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))

                {

                    connection.Open();

                    String del_tracks = "DELETE FROM `Tracks` WHERE id_Album = @id";

                    using (MySqlCommand command = new MySqlCommand(del_tracks, connection))

                    {

                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();

                    }

                }

            }

            catch (Exception ex)
            {

            }

            Deletar();
            redirecionar();

        }

        void Deletar()
        {

            try

            {

                String id = Request.Query["id"];

                string connectionString = "Server=localhost;Port=3306;Database=music;Uid=admin;Pwd=Senha13n;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))

                {

                    connection.Open();

                    String sql = "DELETE FROM `albums` WHERE id = @id";

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

            redirecionar();
        }
        void redirecionar()
        {

            Console.WriteLine("oi");
            //Response.Redirect("/Albums/Index");

        }
    }
}



