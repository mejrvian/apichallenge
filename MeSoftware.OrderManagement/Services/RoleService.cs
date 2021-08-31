using System;
using System.Linq;
using System.Threading.Tasks;
using MeSoftware.Core;
using MeSoftware.Exceptions.Api;
using MeSoftware.OrderManagement.Contexts;
using MeSoftware.OrderManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MeSoftware.OrderManagement.Services
{
    public class RoleService : IRoleService
    {
        private readonly MeContext context;

        public RoleService(MeContext context)
        {
            this.context = context;
        }

        public async Task<AuthorizedRoleViewModel> GetUserRoleAsync(Guid userId, int minimunRoleLevel, int[] module)
        {

            var user = await context.Users
                .Where(n => n.Id == userId)
                .Include(n => n.Roles)
                .FirstOrDefaultAsync();
            var mod = await context.Modules
                .Where(n => n.ModuleNo.In(module))
                .Select(n => n.ModuleName)
                .Distinct()
                .ToArrayAsync();

            if (user.IsNotNull().And(mod.Any()).Not())
                throw new MeAuthorizeException("Forbidden.");

            var authorizedRoles = await context.Roles
                    .Where(n => n.Id.In(user.Roles.Select(r => r.RoleId).ToArray()))
                    .Where(n => n.Modules.In(mod) && n.RoleLevel >= minimunRoleLevel)
                    .Select(n => n.SutId)
                    .Distinct()
                    .ToArrayAsync();

            if (authorizedRoles.Any().Not())
                throw new MeAuthorizeException("Forbidden.");

            return new AuthorizedRoleViewModel
            {
                UserId = userId,
                RoleLevel = minimunRoleLevel,
                Authorized = authorizedRoles.Any(),
                Module = mod,
            };
        }
    }
}
