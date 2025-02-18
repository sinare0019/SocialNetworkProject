using SCN.Domain.Entity;
using SCN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.DA.IRepository
{
    public interface IPostCommentRepository
    {
        Task<Result<bool>> AddAsync(PostComment postComment, CancellationToken cancellationToken);
    }
}
