using healthmanagementapi.DB;
using healthmanagementapi.Entities;
using healthmanagementapi.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace healthmanagementapi.Services
{
    public interface IRoleService 
    {
        Task<List<Role>> GetAllRolesAsync();
        Task<Role> GetRoleByIdAsync(string id);
        Task<IdentityResult> CreateRoleAsync(Role role);
        Task<IdentityResult> UpdateRoleAsync(Role facility);
        Task<IdentityResult> DeleteRoleAsync(int id);
        Task<IdentityResult> AssignRoleToUserAsync(string userId, string roleId);
    }

    public class RoleService:IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IRepository<Role> _roleRepository;
        private readonly HealthDbContext _context;

        public RoleService(HealthDbContext context,RoleManager<IdentityRole> roleManager, UserManager<User> userManager,IRepository<Role> roleRepository)
        {
            _roleManager = roleManager;
            _roleRepository = roleRepository;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IdentityResult> AssignRoleToUserAsync(string userId, string roleId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var role = await _roleManager.FindByIdAsync(roleId);

            if (user == null || role == null)
                return IdentityResult.Failed(new IdentityError { Description = "User or Role not found" });

            return await _userManager.AddToRoleAsync(user, role.Name);
        }

        public async Task<IdentityResult> CreateRoleAsync(Role role)
        {
            var identityRole = new IdentityRole(role.Name);
            return await _roleManager.CreateAsync(identityRole);
        }

        public async Task<IdentityResult> DeleteRoleAsync(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
                return IdentityResult.Failed(new IdentityError { Description = "Role not found" });

            return await _roleManager.DeleteAsync(role);
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(string id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<IdentityResult> UpdateRoleAsync(Role role)
        {
            var existingRole = await _roleManager.FindByIdAsync(role.Id.ToString());
            if (existingRole == null)
                return IdentityResult.Failed(new IdentityError { Description = "Role not found" });

            existingRole.Name = role.Name;
            return await _roleManager.UpdateAsync(existingRole);
        }
    }
}
