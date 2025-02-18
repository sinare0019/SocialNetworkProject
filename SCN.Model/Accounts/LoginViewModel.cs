using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.Model.Accounts
{
    public record LoginViewModel {
        public string UserName { get; init; }
        public string Password { get; init; }
    }
}
