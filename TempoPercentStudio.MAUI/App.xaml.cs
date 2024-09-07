using SQLite;
using TempoPercentStudio.MAUI.Entities.PersonalBests;
using TempoPercentStudio.MAUI.Shared.Database;

namespace TempoPercentStudio.MAUI
{
    public partial class App : Application
    {
        private readonly SqliteConnectionFactory _sqliteConnectionFactory;

        public App(SqliteConnectionFactory sqliteConnectionFactory)
        {
            InitializeComponent();

            MainPage = new AppShell();
            
            _sqliteConnectionFactory = sqliteConnectionFactory;
        }

        protected override async void OnStart()
        {
            try
            {
                ISQLiteAsyncConnection connection = _sqliteConnectionFactory.Connect();

                await connection.CreateTableAsync<PersonalBestDto>();
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error", "Failed to initialize database.", "Ok");
            }

            base.OnStart();
        }
    }
}
