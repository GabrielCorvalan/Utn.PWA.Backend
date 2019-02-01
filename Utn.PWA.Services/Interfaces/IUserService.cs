using Utn.PWA.DTOs;

namespace Utn.PWA.Services.Interfaces
{
    public interface IUserService
    {
        string Authenticate(UserLoginDTO userLogin);
    }
}
