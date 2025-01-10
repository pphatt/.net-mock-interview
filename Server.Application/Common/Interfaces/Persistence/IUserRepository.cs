using Server.Domain.Entity.Identity;

namespace Server.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task CompleteAsync();
    Task<AppUser?> FindByEmailAsync(string email);
    Task<List<AppUser>> GetAllAsync();
    Task<AppUser> GetUserByIdAsync(Guid Id);
    Task CreateUserAsync(AppUser user);
    Task DeleteUserAsync(AppUser user);
}
