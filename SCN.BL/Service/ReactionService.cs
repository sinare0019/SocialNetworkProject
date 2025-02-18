using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SCN.BL.IService;
using SCN.DA.IRepository;
using SCN.Domain.Entity;
using SCN.Model;
using SCN.Model.Reaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.BL.Service
{
    public class ReactionService : IReactionService
    {
        private readonly IReactionRepository _reactionRepository;
        public ReactionService(IReactionRepository reactionRepository)
        {
            _reactionRepository = reactionRepository;
        }
        public async Task<Result<bool>> AddAsync(ReactionViewModel reaction,int userId, CancellationToken cancellationToken)
        {
            var model = new Reaction
            {
                Id = reaction.Id,
                Post_Id = reaction.Post_Id,
                ReactionType = (Domain.Entity.ReactionType)reaction.ReactionType,
                Date = reaction.Date,
                User_Id = userId
            };
            var reactionExist = await _reactionRepository.ReactionExistAsync(model, cancellationToken);
            if (reactionExist == null)
            {
              return await _reactionRepository.AddAsync(model, cancellationToken);
            }
            else
            {
                model.Id = reactionExist.Id;
              return await _reactionRepository.UpdateAsync(model, cancellationToken);
            }
        }

    }
}
