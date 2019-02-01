using Utn.PWA.DTOs;

namespace Utn.PWA.Repository.Interfaces
{
    public interface IUserRepository
    {
        UsersDTO Authenticate(UserLoginDTO user);
    }
}
