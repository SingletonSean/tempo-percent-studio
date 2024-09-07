namespace TempoPercentStudio.MAUI.Pages;

public partial class AddPersonalBestView : ContentPage
{
	public AddPersonalBestView(AddPersonalBestViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}