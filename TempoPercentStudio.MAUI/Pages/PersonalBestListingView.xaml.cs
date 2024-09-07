using System.Windows.Input;

namespace TempoPercentStudio.MAUI.Pages;

public partial class PersonalBestListingView : ContentPage
{
	public static readonly BindableProperty OnAppearingCommandProperty =
		BindableProperty.Create(nameof(OnAppearingCommand), typeof(ICommand), typeof(PersonalBestListingView), null);

	public ICommand OnAppearingCommand
	{
		get => (ICommand)GetValue(OnAppearingCommandProperty);
		set => SetValue(OnAppearingCommandProperty, value);
	}

	public PersonalBestListingView(PersonalBestListingViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
		OnAppearingCommand?.Execute(null);

        base.OnAppearing();
    }
}