namespace TempoPercentStudio.MAUI.Entities.PersonalBests
{
    public class PersonalBest
    {
        public int Id { get; }
        public double Distance { get; }
        public TimeSpan Time { get; }

        public PersonalBest(int id, double distance, TimeSpan time)
        {
            Id = id;
            Distance = distance;
            Time = time;
        }
    }
}
