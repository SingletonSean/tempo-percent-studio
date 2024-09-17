namespace TempoPercentStudio.MAUI.Shared.Components
{
    public class NumericRangeEntry : Entry
    {
        public static readonly BindableProperty MinimumProperty =
            BindableProperty.Create(nameof(Minimum), typeof(double), typeof(NumericRangeEntry), 0.0);

        public double Minimum
        {
            get => (double)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, value);
        }

        public static readonly BindableProperty MaximumProperty =
            BindableProperty.Create(nameof(Maximum), typeof(double), typeof(NumericRangeEntry), 100.0);

        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public NumericRangeEntry()
        {
            TextChanged += NumericRangeEntry_TextChanged;
        }

        private void NumericRangeEntry_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                Text = Minimum.ToString();
                return;
            }

            if (!double.TryParse(e.NewTextValue, out double newDoubleValue))
            {
                Text = e.OldTextValue;
                return;
            }

            if (newDoubleValue > Maximum)
            {
                Text = Maximum.ToString();
                return;
            }
        }
    }
}
