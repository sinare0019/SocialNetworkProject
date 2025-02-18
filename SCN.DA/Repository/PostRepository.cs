using Microsoft.EntityFrameworkCore;
using SCN.DA.EFCore.Context;
using SCN.DA.IRepository;
using SCN.Domain.Entity;
using SCN.Model;
using SCN.Model.Post;
using System.Threading;

namespace SCN.DA.Repository
{
    public class PostRepository : IPostRepository
    {
        public readonly SCNContext _context;
        public PostRepository(SCNContext context)
        {
            _context = context;
        }
        public async Task<Result<bool>> AddAsync(Post post, CancellationToken cancellationToken)
        {
            try
            {
            await _context.Posts.AddAsync(post, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
                return new Result<bool> { Data = true, IsSuccess = true };
            }
            catch (Exception)
            {
                return new Result<bool> { Data = true, IsSuccess = true };
            }
        }

        public async Task<IList<PostViewModel>> TopPostsAsync(CancellationToken cancellationToken)
        {
            return await _context.Posts
             .Select(p => new PostViewModel
             {
                 Id = p.Id,
                 Title = p.Title,
                 Content = p.Content,
                 Date = p.Date,
                 User_Id = p.User_Id,
                 PostCreatorUser = p.User.Name + " " + p.User.LastName,
                 DisLikeCount = p.Reactions.Count(r => r.ReactionType == ReactionType.DisLike),
                 LikeCount = p.Reactions.Count(r => r.ReactionType == ReactionType.Like),
                 CommentCount = p.PostComments.Count(r => r.Post_Id == p.Id),
             })
                 .OrderByDescending(p => p.LikeCount)
                 .Take(5)
                 .ToListAsync(cancellationToken);
        }

        public async Task<IList<PostViewModel>> WorstPostsAsync(CancellationToken cancellationToken)
        {
            return await _context.Posts
             .Select(p => new PostViewModel
             {
                 Id = p.Id,
                 Title = p.Title,
                 Content = p.Content,
                 Date = p.Date,
                 User_Id = p.User_Id,
                 PostCreatorUser = p.User.Name + " " + p.User.LastName,
                 DisLikeCount = p.Reactions.Count(r => r.ReactionType == ReactionType.DisLike),
                 LikeCount = p.Reactions.Count(r => r.ReactionType == ReactionType.Like),
                 CommentCount = p.PostComments.Count(r => r.Post_Id == p.Id),
             })
                 .OrderByDescending(p => p.DisLikeCount)
                 .Take(5)
                 .ToListAsync(cancellationToken);
        }



    }
}
