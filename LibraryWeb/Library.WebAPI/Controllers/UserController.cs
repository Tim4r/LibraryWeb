using Library.BL;
using Library.Core.ViewDto;
using Library.Data.Models;
using Library.WebAPI.Mapper;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Library.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [Route("~/api/Register")]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserViewDto userViewDto)
    {
        try
        {
            var user = ViewDtoToDtoMapper.Mapper.Map<User>(userViewDto);
            var response = await _userService.Register(user);
            var apiResult = ApiResult<User>.Success(response);
            return Ok(apiResult);
        }
        catch (Exception ex)
        {
            var apiResult = ApiResult<User>.Failure(new[] { ex.Message });
            return Problem(detail: JsonSerializer.Serialize(apiResult));
        }
    }

    //[AllowAnonymous]
    //[Route("~/api/Login")]
    //[HttpPost]
    //public async Task<IActionResult> Login([FromBody] UserViewDto userViewDto)
    //{
    //    try
    //    {
    //        var user = ApiMapper.Mapper.Map<User>(userViewDto);
    //        var response = await _userService.Login(user);
    //        var apiResult = ApiResult<UserModel>.Success(response);
    //        return Ok(apiResult);
    //    }
    //    catch (Exception ex)
    //    {
    //        var apiResult = ApiResult<UserModel>.Failure(new[] { ex.Message });
    //        return Problem(detail: JsonSerializer.Serialize(apiResult));
    //    }
    //}
}
