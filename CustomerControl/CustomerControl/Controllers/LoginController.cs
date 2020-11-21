using CustomerControl.Auth;
using CustomerControl.Business.Interface;
using CustomerControl.Controllers.Base;
using CustomerControl.CrossCutting.Dto.Base;
using CustomerControl.CrossCutting.Dto.Login;
using CustomerControl.CrossCutting.Filter;
using CustomerControl.CrossCutting.Helper;
using CustomerControl.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerControl.Controllers
{
    [Route("api/v1/login")]
    public class LoginController : BaseController<User, UserFilter, LoginDTO, LoginDTO, BaseUpdateDTO>
    {
        private readonly IUserService _userService;

        public LoginController(IUserService baseService) : base(baseService)
        {
            _userService = baseService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult Login([FromBody] LoginDTO dto)
        {
            var login = _userService.Login(dto.Login, EncryptHelper.EncryptPassword(dto.Password));
            var token = UserManagement.RegisterUser(login);

            return Ok(token);
        }
    }
}