using Project1.Interfaces;

namespace Project1.Helpers
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}
