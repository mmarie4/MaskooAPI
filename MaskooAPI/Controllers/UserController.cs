using AutoMapper;
using MaskooAPI.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Services.Users;
using Services.Users.Models;
using System.Threading.Tasks;

namespace MaskooAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<UserResponse> Login([FromBody] LoginRequest loginRequest)
        {
            var loginParameter = _mapper.Map<LoginParameter>(loginRequest);
            var (user, token) = await _userService.Login(loginParameter);

            var result = _mapper.Map<UserResponse>(user);
            result.Token = token;
            return result;
        }

        [HttpPost("sign-up")]
        public async Task<UserResponse> SignUp([FromBody] SignUpRequest signUpRequest)
        {
            var parameter = _mapper.Map<SignUpParameter>(signUpRequest);
            var (user, token) = await _userService.SignUpAsync(parameter);

            var result = _mapper.Map<UserResponse>(user);
            result.Token = token;
            return result;
        }
    }
}
