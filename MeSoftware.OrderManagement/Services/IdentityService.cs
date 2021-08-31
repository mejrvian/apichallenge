using System;
using System.Threading.Tasks;
using MeSoftware.OrderManagement.ViewModels;
using Microsoft.AspNetCore.Http;

namespace MeSoftware.OrderManagement.Services
{
    public class IdentityService : IIdentityService
    {
        public IdentityService(IRoleService roleService, IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext;
            this.roleService = roleService;
            UserName = httpContext.HttpContext.User.Identity.Name;
        }

        private readonly IHttpContextAccessor httpContext;
        private readonly IRoleService roleService;

        public string UserName { get; }

        public async Task<AuthorizedRoleViewModel> GetUserRoleAsync(int minimunRoleLevel, int[] module)
        {
            return await roleService.GetUserRoleAsync(Guid.Parse(UserName), minimunRoleLevel, module);
        }
    }
}
