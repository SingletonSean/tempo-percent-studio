using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempoPercentStudio.MAUI.Entities.PersonalBests
{
    public partial class PersonalBestListingItemViewModel : ObservableObject
    {
        private readonly Func<PersonalBestListingItemViewModel, Task> _onDelete;

        public string Distance { get; }
        public string Time { get; }

        public PersonalBestListingItemViewModel(Func<PersonalBestListingItemViewModel, Task> onDelete)
        {
            _onDelete = onDelete;

            Distance = "400m";
            Time = "0:49.31";
        }

        [RelayCommand]
        public async Task DeletePersonalBest()
        {
            await _onDelete(this);
        }
    }
}
