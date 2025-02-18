using Microsoft.EntityFrameworkCore;
using SCN.DA.EFCore.Context;
using SCN.DA.IRepository;
using SCN.Domain.Entity;
using SCN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SCN.DA.Repository
{
    public class ReactionRepository : IReactionRepository
    {
        public readonly SCNContext _context;
        public ReactionRepository(SCNContext context)
        {
            _context = context;
        }
        public async Task<Result<bool>> AddAsync(Reaction reaction, CancellationToken cancellationToken)
        {
            try
            {
                await _context.Reactions.AddAsync(reaction, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return new Result<bool> { Data = true, IsSuccess = true };
            }
            catch (Exception)
            {
                return new Result<bool> { Data = false, IsSuccess = false };
            }
        }

        public async Task<Result<bool>> UpdateAsync(Reaction reaction, CancellationToken cancellationToken)
        {
            try
            {
                _context.Reactions.Update(reaction);
                await _context.SaveChangesAsync(cancellationToken);
                return new Result<bool> { Data = true, IsSuccess = true };
            }
            catch (Exception)
            {
                return new Result<bool> { Data = false, IsSuccess = false };
            }
        }
        //برای مشخص کردن اینکه اگه کاربر قبلا پست را لایک یا دیسلایک کرده مشخص بشه
        public async Task<Reaction> ReactionExistAsync(Reaction reaction, CancellationToken cancellationToken)
        {
            return await _context.Reactions.AsNoTracking()
                .Where(x => x.Post_Id == reaction.Post_Id && x.User_Id == reaction.User_Id)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
