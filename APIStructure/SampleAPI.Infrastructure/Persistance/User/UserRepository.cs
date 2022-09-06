using SampleAPI.Application.Common.Interfaces;
using SampleAPI.Domain.Entities;

namespace SampleAPI.Infrastructure.Persistance.User
{
    public class UserRepository : IUserRepository
    {
        public static readonly List<Domain.Entities.User> _users = new();
        void IUserRepository.Add(Domain.Entities.User user)
        {
            _users.Add(user);
        }

        Domain.Entities.User? IUserRepository.GetUserByMail(string email)
        {
            return _users.SingleOrDefault(x => x.Email == email);
        }
    }
}
