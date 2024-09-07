namespace TempoPercentStudio.MAUI.Pages;

public partial class PersonalBestListingView : ContentPage
{
	public PersonalBestListingView(PersonalBestListingViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}