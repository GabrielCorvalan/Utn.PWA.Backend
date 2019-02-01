using Utn.PWA.DTOs;

namespace Utn.PWA.Services.Interfaces
{
    public interface IUserService
    {
        UsersDTO Authenticate(UserLoginDTO userLogin);
    }
}
