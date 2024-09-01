using Cafe.Contracts.Core;
using Cafe.Domain.Features.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Infrastructure.Common
{
    public class DataBaseSeeder : IDataBaseSeeder
    {
        private readonly UserManager<RawaanUser> _userManger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly RawaanDBContext _context;
        public DataBaseSeeder(UserManager<RawaanUser> userManger, RoleManager<IdentityRole> roleManager, RawaanDBContext context)
        {
            _userManger = userManger;
            _roleManager = roleManager;
            _context = context;
        }
        public async Task Seed()
        {
            await AddAutoMigrator();

            await EnsureRolesExist();

            var dbAdmin = await _userManger.FindByNameAsync("admin");

            if (dbAdmin == null)
            {
                RawaanUser adminUser = new()
                {
                    UserName = "admin",
                };
                await _userManger.CreateAsync(adminUser, "12345");
                await _userManger.AddToRoleAsync(adminUser, CafeRoles.Admin.ToString());
            }
        }

        public async Task AddAutoMigrator()
        {
            await _context.Database.MigrateAsync();
        }

        public async Task EnsureRolesExist()
        {
            var dbRoles = _roleManager.Roles.Select(r => r.Name).ToList();

            foreach (var role in Enum.GetValues<CafeRoles>())
            {
                var roleName = role.ToString();

                if (!dbRoles.Contains(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}