using Microsoft.EntityFrameworkCore;
using Server.Application.Common.Interfaces.Persistence;
using Server.Domain.Entity.Identity;
using Server.Infrastructure.Persistence;

namespace Server.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;

    public UserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task CompleteAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<AppUser?> FindByEmailAsync(string email)
    {
        return await _appDbContext.AppUsers.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<List<AppUser>> GetAllAsync()
    {
        var users = await _appDbContext.AppUsers.ToListAsync();

        return users;
    }

    public async Task<AppUser> GetUserByIdAsync(Guid Id)
    {
        var user = await _appDbContext.AppUsers.FirstOrDefaultAsync(x => x.Id == Id);

        //if (user == null)
        //{
        //    return Errors.Users.NotFound;
        //}

        return user;
    }

    public async Task CreateUserAsync(AppUser user)
    {
        await _appDbContext.AppUsers.AddAsync(user);
        await CompleteAsync();
    }

    public async Task DeleteUserAsync(AppUser user)
    {
        _appDbContext.AppUsers.Remove(user);
        await CompleteAsync();
    }
}
