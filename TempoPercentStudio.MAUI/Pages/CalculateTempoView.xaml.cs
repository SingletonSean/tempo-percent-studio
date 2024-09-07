using System.Windows.Input;

namespace TempoPercentStudio.MAUI.Pages;

public partial class CalculateTempoView : ContentPage
{
    public static readonly BindableProperty OnAppearingCommandProperty =
    BindableProperty.Create(nameof(OnAppearingCommand), typeof(ICommand), typeof(CalculateTempoView), null);

    public ICommand OnAppearingCommand
    {
        get => (ICommand)GetValue(OnAppearingCommandProperty);
        set => SetValue(OnAppearingCommandProperty, value);
    }

    public CalculateTempoView(CalculateTempoViewModel viewModel)
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