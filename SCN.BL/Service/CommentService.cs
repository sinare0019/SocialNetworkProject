using SCN.BL.IService;
using SCN.DA.IRepository;
using SCN.Domain.Entity;
using SCN.Model;
using SCN.Model.Comment;
using System;
using System.Runtime.InteropServices;

namespace SCN.BL.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostCommentRepository _postCommentRepository;
        public CommentService(ICommentRepository commentRepository, IPostCommentRepository postCommentRepository)
        {
            _commentRepository = commentRepository;
            _postCommentRepository = postCommentRepository;
        }

        public async Task<Result<bool>> AddAsync(CommentViewModel comment, int userId, CancellationToken cancellationToken)
        {
            var model = new Comment
            {
                Date = comment.CommentDate.Value,
                Content = comment.CommentContent,
                User_Id = userId
            };
            try
            {
                //save and recive comment id
                var commentId = _commentRepository.AddAsync(model, cancellationToken);
                var postCommentModel = new PostComment
                {
                    Comment_Id = commentId.Result,
                    Post_Id = comment.Post_Id.Value,
                };
                await _postCommentRepository.AddAsync(postCommentModel, cancellationToken);
                return new Result<bool> { Data = true, IsSuccess = true };

            }
            catch (Exception)
            {

                return new Result<bool> { Data = false, IsSuccess = false };
            }
        

        }

        public async Task<IList<CommentViewModel>> GetCommentsAsync(int postId, CancellationToken cancellationToken)
        {
            return await _commentRepository.GetCommentsAsync(postId, cancellationToken);
        }
    }
}
