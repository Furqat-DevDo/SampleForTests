using System.Text.Json;
using Web.Data;
using Web.Entities;
using Web.Models;

namespace Web.Services;

public class UserService : IUserService
{
    private readonly AppDBContext _appDBContext;
    public UserService(AppDBContext appDBContext)
    {
        _appDBContext = appDBContext;
    }

    public UserModel CreateUser(UserCreateModel createUserModel)
    {
        var user = new User
        {
            FullName = createUserModel.FullName,
            Age = createUserModel.Age,
            Email = createUserModel.Email,
            PersonalData = JsonSerializer.SerializeToDocument(createUserModel.PersonalData),
        };

        var createdUser = _appDBContext.Users.Add(user);
        _appDBContext.SaveChanges();
        return new UserModel
        {
            FullName = createdUser.Entity.FullName,
            Email = createdUser.Entity.Email,
            Age = createdUser.Entity.Age,
            PersonalData = createdUser.Entity.PersonalData,
            Id = createdUser.Entity.Id
        };
    }

    public List<UserModel> GetAll()
    {
        return _appDBContext.Users.
        Select( u=> 
        new UserModel
        {
            Age = u.Age,
            FullName = u.FullName,
            Id = u.Id,
            Email = u.Email,
            PersonalData = u.PersonalData,
        })
        .ToList();
    }

    public UserModel? GetById(uint id)
    {
        var user = _appDBContext.Users.FirstOrDefault( u => u.Id == id);
        return user is null ? null : 
        new UserModel
        {
            Id = user.Id,
            FullName = user.FullName,
            PersonalData = user.PersonalData,
            Age = user.Age,
            Email = user.Email,
        };
    }
}