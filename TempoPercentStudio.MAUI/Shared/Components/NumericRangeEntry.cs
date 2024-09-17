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
            BindableProperty.Create(nameof(Maximum), typeof(double?), typeof(NumericRangeEntry), null);

        public double? Maximum
        {
            get => (double?)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public static readonly BindableProperty MaximumDecimalPlacesProperty =
            BindableProperty.Create(nameof(MaximumDecimalPlaces), typeof(int), typeof(NumericRangeEntry), 0);

        public int MaximumDecimalPlaces
        {
            get => (int)GetValue(MaximumDecimalPlacesProperty);
            set => SetValue(MaximumDecimalPlacesProperty, value);
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

            string[] decimalSplitNewText = e.NewTextValue.Split('.');
            bool hasDecimals = decimalSplitNewText.Length > 1;

            if (hasDecimals)
            {
                if (MaximumDecimalPlaces == 0)
                {
                    Text = e.OldTextValue;
                    return;
                }

                string decimals = decimalSplitNewText[1];

                if (decimals.Length > MaximumDecimalPlaces)
                {
                    Text = e.OldTextValue;
                    return;
                }
            }

            if (!double.TryParse(e.NewTextValue, out double newDoubleValue))
            {
                Text = e.OldTextValue;
                return;
            }

            if (Maximum != null && newDoubleValue > Maximum)
            {
                Text = Maximum.ToString();
                return;
            }
        }
    }
}
