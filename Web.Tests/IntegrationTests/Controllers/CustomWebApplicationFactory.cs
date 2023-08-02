using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Web.Services;

namespace Web.Tests.IntegrationTests.Controllers;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    private readonly Mock<IUserService> _mockService;

    public CustomWebApplicationFactory(Mock<IUserService> mockService)
    {
        _mockService = mockService;
    }
}