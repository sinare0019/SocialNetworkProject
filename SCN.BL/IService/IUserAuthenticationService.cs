using SCN.Domain.Entity;
using SCN.Model.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.BL.IService
{
    public interface IUserAuthenticationService
    {
       string GetJwtToken(UserViewModel user, CancellationToken cancellationToken);
    }
}
