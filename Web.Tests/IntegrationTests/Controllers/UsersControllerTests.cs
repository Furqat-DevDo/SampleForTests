using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Web.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Web.Tests.IntegrationTests.Controllers;

public class UsersControllerTests
{

    private HttpClient _httpClient = new CustomWebApplicationFactory().CreateClient();

    [Fact]

    public async Task Should_Return_New_UserModel()
    {
        var newUser = new UserCreateModel()
        {
           Age = 28,
           FullName = "Furqat Abduvosiqov",
           Email = "furqat@gmail.com",
           PersonalData = JsonSerializer.SerializeToDocument(new 
           { 
               Adrress = "Farobiy ko'cha Toshkent Shahri",
               Passport = "Passport"
           })
        };

        var request = new HttpRequestMessage(HttpMethod.Post, "users");
        request.Content = new StringContent(
            content: JsonConvert.SerializeObject(newUser),
            encoding: Encoding.UTF8,
            mediaType: "application/json");

        var response = await _httpClient.SendAsync(request);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var result = JsonConvert.DeserializeObject<UserModel>(
            await response.Content.ReadAsStringAsync());

        Assert.NotNull(result);
        result.Id.Should().BeGreaterThan(0);
        result.Age.Should().Be(28);
        result.FullName.Should().Be("Furqat Abduvosiqov");
        Assert.NotNull(result.PersonalData);
    }

    [Fact]
    public async Task Shoud_Return_List_Of_UserModel_Or_Empty_List()
    {
        var request = new HttpRequestMessage(HttpMethod.Get,"users");

        var response = await _httpClient.SendAsync(request);

        var result = JsonConvert.DeserializeObject<List<UserModel>>(
            await response.Content.ReadAsStringAsync());

        Assert.NotNull(result);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        if (result.Any())
        {
            result.First().GetType().Should().Be(typeof(UserModel));
        }

    }

    [Fact]
    public async Task Should_Return_UserModel_With_Given_Id()
    {
        
        int userId = 1; 

        var request = new HttpRequestMessage(HttpMethod.Get, $"users/{userId}");

        var response = await _httpClient.SendAsync(request);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var result = JsonConvert.DeserializeObject<UserModel>(
            await response.Content.ReadAsStringAsync());

        Assert.NotNull(result);
        result.Id.Should().Be(userId);
        result.Age.Should().BeGreaterThan(0); 
        result.FullName.Should().NotBeNullOrEmpty(); 
                                            
        Assert.NotNull(result.PersonalData);
    }
}
