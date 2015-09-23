using BLL.BusinessModels;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProfileService
    {
        UserDTO GetUserByEmail(string email);
        List<UserEdition> GetUserEditions(int userId);
        //void ChangeUserData(string propertyId, string newValue, int userId);
        void ChangeFirstName(string firstName, string cur_email);
        void ChangeLastName(string lastName, string cur_email);
        void ChangeEmail(string email, string cur_email);
        void AddCash(double cash, string email);
        bool ChangePassword(string oldPassword, string newPassword, string email);
        void DeleteAccount(int userId);
        void Dispose();
    }
}
