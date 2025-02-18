using SCN.Domain.Entity;
using SCN.Model;
using SCN.Model.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.BL.IService
{
    public interface IPostService
    {
        Task<Result<bool>> AddAsync(PostViewModel post,int userId, CancellationToken cancellationToken);
        Task<IList<PostViewModel>> TopPostsAsync(CancellationToken cancellationToken);
        Task<IList<PostViewModel>> WorstPostsAsync( CancellationToken cancellationToken);
    }
}
