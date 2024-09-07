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

                double percentEffortDecimal = PercentEffort / 100.0;
                double personalBestMilliseconds = SelectedPersonalBest.PersonalBest.Time.TotalMilliseconds;

                double calculatedMilliseconds = personalBestMilliseconds * (2 - percentEffortDecimal);
                TimeSpan calculatedTime = TimeSpan.FromMilliseconds(calculatedMilliseconds);

                return calculatedTime.ToString();
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
