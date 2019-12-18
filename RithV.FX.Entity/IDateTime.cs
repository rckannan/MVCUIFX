using System;

namespace RithV.FX.Entity
{
    public interface IDateTime
    {
        DateTime DateNow { get; }
    }

    public class DateTimeAdapter : IDateTime
    {
        public DateTime DateNow
        {
            get { return DateTime.Now; }
        }
    }

    public class DateTimeAdapterUTC : IDateTime
    {
        public DateTime DateNow
        {
            get { return DateTime.UtcNow; }
        }
    }
}