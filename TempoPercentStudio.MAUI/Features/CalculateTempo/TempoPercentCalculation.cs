namespace TempoPercentStudio.MAUI.Features.CalculateTempo
{
    public class TempoPercentCalculation
    {
        public int PercentEffortInput { get; set; }
        public TimeSpan TimeInput { get; set; }

        public TimeSpan TimeOutput
        {
            get
            {
                double percentEffortInputDecimal = PercentEffortInput / 100.0;
                double timeInputMilliseconds = TimeInput.TotalMilliseconds;

                double calculatedMilliseconds = timeInputMilliseconds * (2 - percentEffortInputDecimal);
                
                return TimeSpan.FromMilliseconds(calculatedMilliseconds);
            }
        }

        public TempoPercentCalculation(int percentEffortInput, TimeSpan timeInput)
        {
            PercentEffortInput = percentEffortInput;
            TimeInput = timeInput;
        }
    }
}
