using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TempoPercentStudio.MAUI.Entities.PersonalBests;

namespace TempoPercentStudio.MAUI.Pages
{
    public partial class AddPersonalBestViewModel : ObservableObject
    {
        private readonly PersonalBestRepository _repository;

        [ObservableProperty]
        private double _distance;

        [ObservableProperty]
        private int _minutes;

        [ObservableProperty]
        private int _seconds;

        [ObservableProperty]
        private string _milliseconds = "00";

        public AddPersonalBestViewModel(PersonalBestRepository repository)
        {
            _repository = repository;
        }

        [RelayCommand]
        private async Task Submit()
        {
            try
            {
                string paddedMilliseconds = Milliseconds.PadRight(3, '0');
                int parsedMilliseconds = int.Parse(paddedMilliseconds);

                await _repository.Create(new NewPersonalBest(
                    Distance,
                    new TimeSpan(0, 0, Minutes, Seconds, parsedMilliseconds)));

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error", "Failed to create personal best. Please try again.", "Ok");
            }
        }
    }
}
