using System.Threading.Tasks;
using MeSoftware.OrderManagement.ViewModels;

namespace MeSoftware.OrderManagement.Services
{
    public interface IIdentityService
    {
        string UserName { get; }
        Task<AuthorizedRoleViewModel> GetUserRoleAsync(int minimunRoleLevel, int[] module);
    }
}
