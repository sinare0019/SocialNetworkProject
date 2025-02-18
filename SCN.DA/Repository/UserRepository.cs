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
    public class UserRepository : IUserRepository
    {
        private readonly SCNContext _context;
        public UserRepository(SCNContext context)
        {
            _context = context;
        }
        //افزودن کاربر جدید
        public async Task<Result<bool>> AddAsync(User user, CancellationToken cancellationToken)
        {
            try
            {
                await _context.Users.AddAsync(user, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return new Result<bool> { Data = true, IsSuccess = true };
            }
            catch (Exception)
            {
                return new Result<bool> { Data = false, IsSuccess = false };
            }
        }
        //واکشی کاربر توسط ایدی
        public async Task<User> GetUserAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Users.FindAsync(id, cancellationToken);
        }

        //وقتی میخواد لاگین کنه میاد اینجا که ببینه ایا کاربری با ان نام کاربری در دیتابیس وجود دارد یا خیر
        public async Task<User> UserExistsAsync(string userName, CancellationToken cancellationToken)
        {
            return await _context.Users
                .Where(u => u.UserName == userName)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
