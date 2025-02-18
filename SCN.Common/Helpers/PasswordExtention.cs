using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace SCN.Common.Helpers
{
    public static class PasswordExtention
    {
        public static async Task<string> HashPassword(this string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool HashVerify(this string password, string dbPass)
        {
           return BCrypt.Net.BCrypt.Verify(password,dbPass);
        }

    }
}
