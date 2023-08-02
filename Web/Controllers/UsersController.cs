using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Services;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]

public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Will return all users or empty list.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<UserModel>),200)]
    public IActionResult GetAll(){
        return Ok(_userService.GetAll());
    }

    /// <summary>
    /// Will return user with the given id.
    /// </summary>
    /// <param name="id">User id</param>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserModel),200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(uint id)
    {
       var searchResult = _userService.GetById(id);
       return searchResult is null ? NotFound() : Ok(searchResult);
    }

    /// <summary>
    /// Will create a new user.
    /// </summary>
    /// <param name="createUserModel">User create model.</param>
    [HttpPost]
    [ProducesResponseType(typeof(UserModel),200)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Post([FromBody] UserCreateModel createUserModel)
    {
        var user = _userService.CreateUser(createUserModel);
        return Ok(user);
    }
}