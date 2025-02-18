using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using SCN.BL.IService;
using SCN.Domain.Entity;
using SCN.Model.Post;

namespace SocialNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : BaseController
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(PostViewModel model, CancellationToken cancellationToken = default)
        {
            var result = await _postService.AddAsync(model, GetUserId(), cancellationToken);
            return new JsonResult(result);
        }

        [HttpGet("top-posts")]
        public async Task<ActionResult> TopPosts(CancellationToken cancellationToken = default)
        {
            var result = await _postService.TopPostsAsync(cancellationToken);
            return new JsonResult(result);
        }

        [HttpGet("worst-posts")]
        public async Task<ActionResult> WorstPosts(CancellationToken cancellationToken = default)
        {
            var result = await _postService.WorstPostsAsync(cancellationToken);
            return new JsonResult(result);
        }

    }
}
