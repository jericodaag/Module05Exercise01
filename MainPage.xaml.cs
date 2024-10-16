using Module07DataAccess.Services;
using MySql.Data.MySqlClient;

namespace Module07DataAccess
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseConnectionService _dbConnectionService;

        public MainPage()
        {
            InitializeComponent();
            _dbConnectionService = new DatabaseConnectionService();
        }

        private async void OnTestConnectionClicked(object sender, EventArgs e)
        {
            var connectionString = _dbConnectionService.GetConnectionString();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    await DisplayAlert("Success", "Connection Successful!", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Connection Failed: {ex.Message}", "OK");
            }
        }

        private async void OpenViewEmployee(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ViewEmployee");
        }
    }
}