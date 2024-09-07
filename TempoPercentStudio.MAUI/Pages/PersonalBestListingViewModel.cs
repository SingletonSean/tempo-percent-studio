using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempoPercentStudio.MAUI.Entities.PersonalBests;

namespace TempoPercentStudio.MAUI.Pages
{
    public partial class PersonalBestListingViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private bool _hasError;

        [ObservableProperty]
        private string? _errorMessage;

        public ObservableCollection<PersonalBestListingItemViewModel> PersonalBests { get; }

        public PersonalBestListingViewModel()
        {
            PersonalBests = new ObservableCollection<PersonalBestListingItemViewModel>()
            {
                new PersonalBestListingItemViewModel(OnPersonalBestDelete),
                new PersonalBestListingItemViewModel(OnPersonalBestDelete),
                new PersonalBestListingItemViewModel(OnPersonalBestDelete),
            };
        }

        private async Task OnPersonalBestDelete(PersonalBestListingItemViewModel viewModel)
        {
            bool confirmed = await Shell.Current.DisplayAlert(
                "Delete Personal Best",
                "Are you sure you want to delete this personal best?",
                "Yes", "No");

            if (!confirmed)
            {
                return;
            }

            PersonalBests.Remove(viewModel);
        }

        [RelayCommand]
        public async Task NavigateAddPersonalBest()
        {
            await Shell.Current.GoToAsync("AddPersonalBest");
        }
    }
}
