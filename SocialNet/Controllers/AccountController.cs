using Microsoft.AspNetCore.Mvc;
using SCN.BL.IService;
using SCN.Common.Helpers;
using SCN.DA.EFCore.Context;
using SCN.Model.Accounts;
using SCN.Model.Register;


namespace SocialNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private readonly SCNContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IUserAuthenticationService _userAuthenticationService;

        public AccountController(SCNContext context,
            IConfiguration configuration,
            IUserService userService,
            IUserAuthenticationService userAuthenticationService)
        {
            _context = context;
            _configuration = configuration;
            _userService = userService;
            _userAuthenticationService = userAuthenticationService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserViewModel model, CancellationToken cancellationToken = default)
        {
           var result =await _userService.AddAsync(model, cancellationToken);
            return new JsonResult(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model, CancellationToken cancellationToken = default)
        {
            var user = await _userService.UserExistsAsync(model.UserName, cancellationToken);
            if (user == null || !model.Password.HashVerify(user.Password))
            {
                return Content("The username or password is incorrect.");
            }
            else
            {
                var token = _userAuthenticationService.GetJwtToken(user, cancellationToken);
                return Ok(new { token });
            }
        }
    }
}
