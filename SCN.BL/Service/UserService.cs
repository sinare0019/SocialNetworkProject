using SCN.BL.IService;
using SCN.Common.Helpers;
using SCN.DA.IRepository;
using SCN.Domain.Entity;
using System.Text;
using Microsoft.Extensions.Configuration;
using SCN.Model.Register;
using System.Threading;
using SCN.Model;
namespace SCN.BL.Repository
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<Result<bool>> AddAsync(UserViewModel user, CancellationToken cancellationToken)
        {
            var passHash = await user.Password.HashPassword();

            var model = new User
            {
                Id = user.Id.Value,
                Email = user.Email,
                Name = user.Name,
                LastName = user.LastName,
                Password = passHash,
                UserName = user.UserName
            };
           return await _userRepository.AddAsync(model, cancellationToken);
        }

        public async Task<UserViewModel> GetUserAsync(int id, CancellationToken cancellationToken)
        {
           var model = await _userRepository.GetUserAsync(id, cancellationToken);
            if (model == null)
            {
                return null;
            }
            return new UserViewModel
            {
                Id = model.Id,
                Email = model.Email,
                Name = model.Name,
                LastName = model.LastName,
                Password = model.Password,
                UserName = model.UserName
            };
        }

        public async Task<UserViewModel> UserExistsAsync(string userName, CancellationToken cancellationToken)
        {
            var model = await _userRepository.UserExistsAsync(userName, cancellationToken);
            if(model == null)
            {
                return null;
            }
            return new UserViewModel
            {
                Id = model.Id,
                Email = model.Email,
                Name = model.Name,
                LastName = model.LastName,
                Password = model.Password,
                UserName = model.UserName
            };
        }

    }
}
