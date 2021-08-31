using System;
using System.Threading.Tasks;
using MeSoftware.OrderManagement.ViewModels;

namespace MeSoftware.OrderManagement.Services
{
    public interface IRoleService
    {
        Task<AuthorizedRoleViewModel> GetUserRoleAsync(Guid userId, int minimunRoleLevel, int[] module);
    }
}
