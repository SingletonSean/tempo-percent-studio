using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TempoPercentStudio.MAUI.Entities.PersonalBests;
using TempoPercentStudio.MAUI.Features.CalculateTempo;

namespace TempoPercentStudio.MAUI.Pages
{
    public partial class CalculateTempoViewModel : ObservableObject
    {
        private readonly PersonalBestRepository _repository;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(DistanceOutput))]
        [NotifyPropertyChangedFor(nameof(TimeOutput))]
        private CalculateTempoPersonalBestViewModel? _selectedPersonalBest;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(DistanceOutput))]
        [NotifyPropertyChangedFor(nameof(TimeOutput))]
        private int _percentEffort = 50;

        public string? DistanceOutput => SelectedPersonalBest?.Distance;

        public string? TimeOutput
        {
            get
            {
                if (SelectedPersonalBest == null)
                {
                    return null;
                }

                TempoPercentCalculation calculation = new TempoPercentCalculation(
                    PercentEffort, 
                    SelectedPersonalBest.PersonalBest.Time);

                return calculation.TimeOutput.ToString();
            }
        }

        [ObservableProperty]
        private bool _hasError;

        [ObservableProperty]
        private string? _errorMessage;

        public ObservableCollection<CalculateTempoPersonalBestViewModel> PersonalBests { get; }

        public CalculateTempoViewModel(PersonalBestRepository repository)
        {
            _repository = repository;

            PersonalBests = new ObservableCollection<CalculateTempoPersonalBestViewModel>();
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
                    PersonalBests.Add(new CalculateTempoPersonalBestViewModel(personalBest));
                }

                HasError = false;
            }
            catch (Exception)
            {
                HasError = true;
                ErrorMessage = "Failed to load personal bests.";
            }
        }
    }
}
