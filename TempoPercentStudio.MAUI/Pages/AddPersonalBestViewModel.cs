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
        private int _milliseconds;

        public AddPersonalBestViewModel(PersonalBestRepository repository)
        {
            _repository = repository;
        }

        [RelayCommand]
        private async Task Submit()
        {
            await _repository.Create(new NewPersonalBest(
                Distance, 
                new TimeSpan(0, 0, Minutes, Seconds, Milliseconds)));

            await Shell.Current.GoToAsync("..");
        }
    }
}
