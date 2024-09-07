using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempoPercentStudio.MAUI.Pages
{
    public partial class AddPersonalBestViewModel : ObservableObject
    {
        [ObservableProperty]
        private double _distance;

        [ObservableProperty]
        private double _minutes;

        [ObservableProperty]
        private double _seconds;

        [ObservableProperty]
        private double _milliseconds;

        [RelayCommand]
        public async Task Submit()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
