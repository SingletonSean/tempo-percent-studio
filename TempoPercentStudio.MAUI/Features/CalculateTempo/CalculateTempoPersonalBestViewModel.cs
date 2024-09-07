using CommunityToolkit.Mvvm.ComponentModel;
using TempoPercentStudio.MAUI.Entities.PersonalBests;

namespace TempoPercentStudio.MAUI.Features.CalculateTempo
{
    public class CalculateTempoPersonalBestViewModel : ObservableObject
    {
        public PersonalBest PersonalBest { get; }

        public int Id => PersonalBest.Id;
        public string Distance => PersonalBest.Distance.ToString();
        public string Time => PersonalBest.Time.ToString();

        public CalculateTempoPersonalBestViewModel(PersonalBest personalBest)
        {
            PersonalBest = personalBest;
        }
    }
}
