using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCN.Common.Helpers;
using System.Security.Claims;

namespace SocialNet.Controllers
{

    public abstract class BaseController : ControllerBase
    {
        protected int GetUserId()
        {
            try
            {
                return int.Parse(HttpContext.User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.Sid).Value);
            }
            catch
            {
                return 0;
            }
        }

    }
}
