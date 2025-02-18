using SCN.Domain.Entity;
using SCN.Model.Comment;

namespace SCN.DA.IRepository
{
    public interface ICommentRepository
    {
        Task<int> AddAsync(Comment comment, CancellationToken cancellationToken);
        Task<IList<CommentViewModel>> GetCommentsAsync(int postId, CancellationToken cancellationToken);
    }
}
