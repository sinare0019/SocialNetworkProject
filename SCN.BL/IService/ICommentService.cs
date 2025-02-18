using Microsoft.AspNetCore.Http.HttpResults;
using SCN.Model;
using SCN.Model.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.BL.IService
{
    public interface ICommentService
    {
        Task<Result<bool>> AddAsync(CommentViewModel comment, int userId, CancellationToken cancellationToken);
        Task<IList<CommentViewModel>> GetCommentsAsync(int postId, CancellationToken cancellationToken);
    }
}
