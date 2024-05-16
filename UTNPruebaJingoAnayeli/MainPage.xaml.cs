using UTNPruebaJingoAnayeli.Models;

namespace UTNPruebaJingoAnayeli
{
    public partial class MainPage : ContentPage
    {
        private string ApiUrlGames = "https://appcloudapi.azurewebsites.net/api/Games";
        private string ApiUrlLaunchers = "https://appcloudapi.azurewebsites.net/api/Launchers";

        public MainPage()
        {
            InitializeComponent();
        }

        private void cmdCreateGame_Clicked(object sender, EventArgs e)
        {
            var resultado = APIConsumer.CrudCrud<Game>.Create(ApiUrlGames, new Game
            {
                Id = 0,
                Name = txtGameName.Text,
                ReleaseDate = DateTime.Parse(txtGameReleaseDate.Text),
                LauncherId = int.Parse(txtGameLauncherId.Text),
                Launcher = null // Asignar un objeto Launcher si es necesario
            });

            if (resultado != null)
            {
                txtGameId.Text = resultado.Id.ToString();
            }
        }

        private void cmdReadGame_Clicked(object sender, EventArgs e)
        {
            var resultado = APIConsumer.CrudCrud<Game>.Read_ById(ApiUrlGames, int.Parse(txtGameId.Text));
            if (resultado != null)
            {
                txtGameId.Text = resultado.Id.ToString();
                txtGameName.Text = resultado.Name;
                txtGameReleaseDate.Text = resultado.ReleaseDate.ToString();
                txtGameLauncherId.Text = resultado.LauncherId.ToString();
                // Asignar los datos del objeto Launcher si es necesario
            }
        }

        private void cmdUpdateGame_Clicked(object sender, EventArgs e)
        {
            APIConsumer.CrudCrud<Game>.Update(ApiUrlGames, int.Parse(txtGameId.Text), new Game
            {
                Id = int.Parse(txtGameId.Text),
                Name = txtGameName.Text,
                ReleaseDate = DateTime.Parse(txtGameReleaseDate.Text),
                LauncherId = int.Parse(txtGameLauncherId.Text),
                Launcher = null // Asignar un objeto Launcher si es necesario
            });
        }

        private void cmdDeleteGame_Clicked(object sender, EventArgs e)
        {
            APIConsumer.CrudCrud<Game>.Delete(ApiUrlGames, int.Parse(txtGameId.Text));
            txtGameName.Text = "";
            txtGameReleaseDate.Text = "";
            txtGameLauncherId.Text = "";
            txtGameId.Text = "";
        }

        // Métodos para Launcher
        private void cmdCreateLauncher_Clicked(object sender, EventArgs e)
        {
            var resultado = APIConsumer.CrudCrud<Models.Launcher>.Create(ApiUrlLaunchers, new Models.Launcher
            {
                Id = 0,
                Name = txtLauncherName.Text,
                GamesList = null // Asignar una lista de juegos si es necesario
            });

            if (resultado != null)
            {
                txtLauncherId.Text = resultado.Id.ToString();
            }
        }

        private void cmdReadLauncher_Clicked(object sender, EventArgs e)
        {
            var resultado = APIConsumer.CrudCrud<Models.Launcher>.Read_ById(ApiUrlLaunchers, int.Parse(txtLauncherId.Text));
            if (resultado != null)
            {
                txtLauncherId.Text = resultado.Id.ToString();
                txtLauncherName.Text = resultado.Name;
                // Asignar los datos de la lista de juegos si es necesario
            }
        }

        private void cmdUpdateLauncher_Clicked(object sender, EventArgs e)
        {
            APIConsumer.CrudCrud<Models.Launcher>.Update(ApiUrlLaunchers, int.Parse(txtLauncherId.Text), new Models.Launcher
            {
                Id = int.Parse(txtLauncherId.Text),
                Name = txtLauncherName.Text,
                GamesList = null // Asignar una lista de juegos si es necesario
            });
        }

        private void cmdDeleteLauncher_Clicked(object sender, EventArgs e)
        {
            APIConsumer.CrudCrud<Models.Launcher>.Delete(ApiUrlLaunchers, int.Parse(txtLauncherId.Text));
            txtLauncherName.Text = "";
            txtLauncherId.Text = "";
        }
    }
}

