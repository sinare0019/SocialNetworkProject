using SCN.Domain.Entity;
using SCN.Model;
using SCN.Model.Reaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.BL.IService
{
    public interface IReactionService
    {
        Task<Result<bool>> AddAsync(ReactionViewModel reaction ,int userId , CancellationToken cancellationToken);
    }
}
