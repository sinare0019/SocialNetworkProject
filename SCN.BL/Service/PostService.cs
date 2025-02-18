
using Microsoft.AspNetCore.Http.HttpResults;
using SCN.BL.IService;
using SCN.DA.IRepository;
using SCN.Domain.Entity;
using SCN.Model;
using SCN.Model.Post;

namespace SCN.BL.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<Result<bool>> AddAsync(PostViewModel post,int userId, CancellationToken cancellationToken)
        {
            var model = new Post
            {
                Content = post.Content,
                Date = post.Date,
                Title = post.Title,
                User_Id = userId,
            };
           return await _postRepository.AddAsync(model, cancellationToken);
        }

        public async Task<IList<PostViewModel>> TopPostsAsync(CancellationToken cancellationToken)
        {
            return await _postRepository.TopPostsAsync(cancellationToken);
        }
        public async Task<IList<PostViewModel>> WorstPostsAsync(CancellationToken cancellationToken)
        {
            return await _postRepository.WorstPostsAsync(cancellationToken);
        }


    }
}
