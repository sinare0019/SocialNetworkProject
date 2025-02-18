using SCN.Domain.Entity;
using SCN.Model;
using SCN.Model.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.DA.IRepository
{
    public interface IUserRepository
    {
        Task<Result<bool>> AddAsync(User user, CancellationToken cancellationToken);
        Task<User> GetUserAsync(int id, CancellationToken cancellationToken);
        Task<User> UserExistsAsync(string userName, CancellationToken cancellationToken);
    }
}
