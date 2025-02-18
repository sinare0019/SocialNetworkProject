using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCN.BL.IService;
using SCN.Model.Reaction;
using System.Threading;

namespace SocialNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReactionController : BaseController
    {
        private readonly IReactionService _reactionService;
        public ReactionController(IReactionService reactionService)
        {
            _reactionService = reactionService;
        }
        
        [HttpPost("create")]
        public async Task<ActionResult> Create(ReactionViewModel model, CancellationToken cancellationToken = default)
        {
           var result = await _reactionService.AddAsync(model, GetUserId(), cancellationToken);
            return new JsonResult(result);
        }

    }
}
