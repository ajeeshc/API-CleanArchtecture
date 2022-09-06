using SampleAPI.Application.Common.Interfaces.Services;

namespace SampleAPI.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
