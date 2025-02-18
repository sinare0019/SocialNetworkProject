using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCN.BL.IService;
using SCN.Model.Comment;
using System.Threading;

namespace SocialNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : BaseController
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create(CommentViewModel model, CancellationToken cancellationToken = default)
        {
            var result = await _commentService.AddAsync(model, GetUserId(), cancellationToken);
            return new JsonResult(result);
        }

        [HttpGet("get-comment")]
        public async Task<ActionResult> GetComment(int postId, CancellationToken cancellationToken = default)
        {
            var result = await _commentService.GetCommentsAsync(postId, cancellationToken);
            return new JsonResult(result);
        }
    }
}
