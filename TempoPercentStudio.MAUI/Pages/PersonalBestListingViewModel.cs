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
        private readonly PersonalBestRepository _repository;

        [ObservableProperty]
        private bool _hasError;

        [ObservableProperty]
        private string? _errorMessage;

        public ObservableCollection<PersonalBestListingItemViewModel> PersonalBests { get; }

        public PersonalBestListingViewModel(PersonalBestRepository repository)
        {
            _repository = repository;

            PersonalBests = new ObservableCollection<PersonalBestListingItemViewModel>();
        }

        [RelayCommand]
        private async Task LoadPersonalBests()
        {
            HasError = false;

            try
            {
                PersonalBests.Clear();

                IEnumerable<PersonalBest> personalBests = await _repository.GetAll();

                foreach (PersonalBest personalBest in personalBests)
                {
                    PersonalBests.Add(new PersonalBestListingItemViewModel(personalBest, OnPersonalBestDelete));
                }

                HasError = false;
            }
            catch (Exception)
            {
                HasError = true;
                ErrorMessage = "Failed to load personal bests.";
            }
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
        private async Task NavigateAddPersonalBest()
        {
            await Shell.Current.GoToAsync("AddPersonalBest");
        }
    }
}
