using Project1.Interfaces;

namespace Project1.Test.Mock
{
    public class DateTimeServiceMock : IDateTimeService
    {
        public DateTime Now => new DateTime(2023, 06, 22);
    }
}
