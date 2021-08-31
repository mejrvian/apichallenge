using MeSoftware.OrderManagement.ViewModels;

namespace MeSoftware.OrderManagement.Services
{
    public interface ITokenService
    {
        LogInResponseViewModel Authenticate(UserLoginViewModel userDto);
    }
}
