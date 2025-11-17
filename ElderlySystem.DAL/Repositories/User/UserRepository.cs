using EderlySystem.DAL.Enums;
using ElderlySystem.DAL.Data;
using ElderlySystem.DAL.Enums;
using ElderlySystem.DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ElderlySystem.DAL.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserRepository(UserManager<ApplicationUser> userManager , ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<List<ApplicationUser>> GetAllUserWithFilterAsync(Status? status = null, Role? role = null)
        {
            var query = _userManager.Users.AsQueryable();

            if (status.HasValue)
                query = query.Where(u => u.Status == status.Value);

            var users = await query.ToListAsync();
            var filteredUsers = new List<ApplicationUser>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Any(r => r.Equals("Admin", StringComparison.OrdinalIgnoreCase)))
                    continue;

                if (role.HasValue)
                {
                    if (roles.Any(r => r.Equals(role.Value.ToString(), StringComparison.OrdinalIgnoreCase)))
                        filteredUsers.Add(user);
                }
                else
                {
                    filteredUsers.Add(user);
                }
            }

            return filteredUsers;
        }

        public async Task<bool> ChangeUserRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return false;

            var currentRoles = await _userManager.GetRolesAsync(user);
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);

            if (!removeResult.Succeeded) return false;

            var addResult = await _userManager.AddToRoleAsync(user, roleName);
            return addResult.Succeeded;
        }
        public async Task<bool> ChangeStatusToggleAsync(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return false;
            }
            user.Status = user.Status == Status.Active ? Status.Inactive : Status.Active;
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<ApplicationUser?> GetByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
                return null;
            return user;

        }
        public async Task<bool> BlockUserAsync(string userId, int days)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return false;
            user.LockoutEnd = DateTime.UtcNow.AddDays(days);
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded; 
        }

        public async Task<bool> UnBlockUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return false;
            user.LockoutEnd = null;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded; 
        }
        public async Task<bool> IsBlockedAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return false;
            return user.LockoutEnd.HasValue && user.LockoutEnd.Value > DateTime.UtcNow;
        }
    }
}
