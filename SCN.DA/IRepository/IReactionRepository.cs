using SCN.Domain.Entity;
using SCN.Model;
using SCN.Model.Reaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.DA.IRepository
{
    public interface IReactionRepository
    {
         Task<Result<bool>> AddAsync(Reaction reaction, CancellationToken cancellationToken);
         Task<Result<bool>> UpdateAsync(Reaction reaction, CancellationToken cancellationToken);
         Task<Reaction> ReactionExistAsync(Reaction reaction, CancellationToken cancellationToken);
    }
}
