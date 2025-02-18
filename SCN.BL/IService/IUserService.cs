using SCN.Domain.Entity;
using SCN.Model;
using SCN.Model.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.BL.IService
{
    public interface IUserService
    {
        Task<Result<bool>> AddAsync(UserViewModel user, CancellationToken cancellationToken);
        Task<UserViewModel> GetUserAsync(int id, CancellationToken cancellationToken);
        Task<UserViewModel> UserExistsAsync(string userName, CancellationToken cancellationToken);

    }
}
