using Moq;
using System.Text.Json;
using Web.Controllers;
using Web.Models;
using Web.Services;

namespace Web.Tests.UnitTests;

public class BookServiceTest
{

    [Fact]
    public void Should_Return_NewUser_When_Parameters_OK()
    {
        var newUser = new UserCreateModel
        {
           FullName = "Test",
           Email = "Test",
           Age = 1,
           PersonalData = JsonSerializer.SerializeToDocument( new{ Adrress= "MyAddress" , Passport = "MyPassport"}),
        };

        

        
    }
}