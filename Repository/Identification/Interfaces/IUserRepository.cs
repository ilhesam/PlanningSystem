using Domain;

namespace Repository;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);
}