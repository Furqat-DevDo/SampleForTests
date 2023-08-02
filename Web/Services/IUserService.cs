using Web.Models;

namespace Web.Services;

public interface IUserService
{
    UserModel CreateUser(UserCreateModel createUserModel);
    List<UserModel> GetAll();
    UserModel? GetById(uint id);
}