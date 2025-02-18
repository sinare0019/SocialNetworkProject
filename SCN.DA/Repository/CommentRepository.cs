using Microsoft.EntityFrameworkCore;
using SCN.DA.EFCore.Context;
using SCN.DA.IRepository;
using SCN.Domain.Entity;
using SCN.Model.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.DA.Repository
{
    public class CommentRepository : ICommentRepository
    {
        public readonly SCNContext _context;
        public CommentRepository(SCNContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Comment comment, CancellationToken cancellationToken)
        {
            try
            {
                await _context.Comments.AddAsync(comment, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return comment.Id;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
        public async Task<IList<CommentViewModel>> GetCommentsAsync(int postId, CancellationToken cancellationToken)
        {
            return await (from c in _context.PostComments
                          where c.Post_Id == postId
                          select new CommentViewModel
                          {
                              CommentContent = c.Comment.Content ?? "",
                              CommentDate = c.Comment.Date,
                              CommentCreatorName = c.Comment.User.Name + " " + c.Comment.User.LastName ?? "",
                              PostTitle = c.Post.Title ?? ""
                          }).ToListAsync(cancellationToken);
        }
    }
}
