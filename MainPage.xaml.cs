using Module07DataAccess.Services;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Module07DataAccess
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private readonly DatabaseConnectionService _dbConnectionService;
        private string _statusMessage;

        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                if (_statusMessage != value)
                {
                    _statusMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainPage()
        {
            InitializeComponent();
            _dbConnectionService = new DatabaseConnectionService();
            BindingContext = this;
        }

        private async void OnTestConnectionClicked(object sender, EventArgs e)
        {
            var connectionString = _dbConnectionService.GetConnectionString();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    StatusMessage = "Connection Successful!";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Connection Failed: {ex.Message}";
            }
        }

        private async void OpenViewEmployee(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ViewEmployee");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}