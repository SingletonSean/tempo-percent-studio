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
        private double _percentEffort = 50;

        public string? DistanceOutput => SelectedPersonalBest?.Distance;

        public string? TimeOutput
        {
            get
            {
                if (SelectedPersonalBest == null)
                {
                    return null;
                }

                PersonalBest personalBest = SelectedPersonalBest.PersonalBest;

                return personalBest.CalculateTempoPercent(PercentEffort).ToString();
            }
        }

        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasError))]
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
            ErrorMessage = null;

            try
            {
                PersonalBests.Clear();

                IEnumerable<PersonalBest> personalBests = await _repository.GetAll();

                foreach (PersonalBest personalBest in personalBests)
                {
                    PersonalBests.Add(new CalculateTempoPersonalBestViewModel(personalBest));
                }
            }
            catch (Exception)
            {
                ErrorMessage = "Failed to load personal bests.";
            }
        }
    }
}
