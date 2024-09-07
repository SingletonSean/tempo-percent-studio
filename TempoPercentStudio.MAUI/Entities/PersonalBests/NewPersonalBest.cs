using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempoPercentStudio.MAUI.Entities.PersonalBests
{
    public class NewPersonalBest
    {
        public double Distance { get; }
        public TimeSpan Time { get; }

        public NewPersonalBest(double distance, TimeSpan time)
        {
            Distance = distance;
            Time = time;
        }
    }
}
