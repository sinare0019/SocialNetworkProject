using Microsoft.AspNetCore.Http;
using SCN.DA.EFCore.Context;
using SCN.DA.IRepository;
using SCN.Domain.Entity;
using SCN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.DA.Repository
{
    public class PostCommentRepository : IPostCommentRepository
    {
        public readonly SCNContext _context;
        public PostCommentRepository(SCNContext context)
        {
            _context = context;
        }
        public async Task<Result<bool>> AddAsync(PostComment model, CancellationToken cancellationToken)
        {
            try
            {
                await _context.PostComments.AddAsync(model, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return new Result<bool> { Data = true, IsSuccess = true };

            }
            catch (Exception)
            {
                return new Result<bool> { Data = false, IsSuccess = false };
            }
        }
    }
}
