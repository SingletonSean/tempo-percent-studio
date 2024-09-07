using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TempoPercentStudio.MAUI.Entities.PersonalBests
{
    public partial class PersonalBestListingItemViewModel : ObservableObject
    {
        private readonly PersonalBest _personalBest;
        private readonly Func<PersonalBestListingItemViewModel, Task> _onDelete;

        public string Distance => _personalBest.Distance.ToString();
        public string Time => _personalBest.Time.ToString();

        public PersonalBestListingItemViewModel(PersonalBest personalBest, Func<PersonalBestListingItemViewModel, Task> onDelete)
        {
            _personalBest = personalBest;
            _onDelete = onDelete;
        }

        [RelayCommand]
        public async Task DeletePersonalBest()
        {
            await _onDelete(this);
        }
    }
}
