namespace TempoPercentStudio.MAUI.Pages;

public partial class CalculateTempoView : ContentPage
{
	public CalculateTempoView(CalculateTempoViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}