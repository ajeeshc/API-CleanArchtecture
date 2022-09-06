using SampleAPI.Domain.Entities;

namespace SampleAPI.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetUserByMail(string email);

    }
}
