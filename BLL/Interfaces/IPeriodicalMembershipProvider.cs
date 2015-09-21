using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace BLL.Interfaces
{
    public interface IPeriodicalMembershipProvider
    {
        bool ValidateUser(string username, string password);
        void Dispose();
    }
}
