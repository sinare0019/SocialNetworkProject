using SCN.Domain.Entity;
using SCN.Model;
using SCN.Model.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.DA.IRepository
{
    public interface IPostRepository
    {
        Task<Result<bool>> AddAsync(Post post, CancellationToken cancellationToken);
        Task<IList<PostViewModel>> TopPostsAsync(CancellationToken cancellationToken);
        Task<IList<PostViewModel>> WorstPostsAsync(CancellationToken cancellationToken);
    }
}
