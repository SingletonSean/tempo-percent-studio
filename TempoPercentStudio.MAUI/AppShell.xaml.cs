using TempoPercentStudio.MAUI.Pages;

namespace TempoPercentStudio.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("PersonalBestListing/AddPersonalBest", typeof(AddPersonalBestView));
        }
    }
}
