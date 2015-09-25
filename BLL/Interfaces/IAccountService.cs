using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        List<UserDTO> GetUserByEmail(string email);
        void CreateUser(UserDTO user);
        bool UserIsBlock(string email);
        void Dispose();
    }
}
