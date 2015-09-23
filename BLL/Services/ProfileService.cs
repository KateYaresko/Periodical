using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using AutoMapper;
using BLL.BusinessModels;

namespace BLL.Services
{
    public class ProfileService : IProfileService
    {
        private IUnitOfWork Db { get; set; }
        public ProfileService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public UserDTO GetUserByEmail(string email)
        {
            Mapper.CreateMap<User, UserDTO>();
            return Mapper.Map<User, UserDTO>(Db.Users.GetBy(user => user.Email == email).FirstOrDefault());
        }

        public List<UserEdition> GetUserEditions(int userId)
        {
            User user = Db.Users.GetByID(userId);
            List<Edition> editions = user.Editions.ToList();

            var userEditions = new List<UserEdition>();
            foreach(var edition in editions)
            {
                userEditions.Add(new UserEdition { EditionName = edition.Name, CategoryName = edition.Category.Name });
            }

            return userEditions;
        }

        public void ChangeFirstName(string firstName, string cur_email)
        {
            User user = Db.Users.GetBy(u => u.Email == cur_email).FirstOrDefault();
            user.FirstName = firstName;
            Db.Users.Update(user);
        }

        public void ChangeLastName(string lastName, string cur_email)
        {
            User user = Db.Users.GetBy(u => u.Email == cur_email).FirstOrDefault();
            user.LastName = lastName;
            Db.Users.Update(user);
        }

        public void ChangeEmail(string email, string cur_email)
        {
            User user = Db.Users.GetBy(u => u.Email == cur_email).FirstOrDefault();
            user.Email = email;
            Db.Users.Update(user);
        }

        public void AddCash(double cash, string email)
        {
            User user = Db.Users.GetBy(u => u.Email == email).FirstOrDefault();
            user.Cash += cash;
            Db.Users.Update(user);
        }

        public bool ChangePassword(string oldPassword, string newPassword, string email)
        {
            User user = Db.Users.GetBy(u => u.Email == email).FirstOrDefault();
            if (user.Password != oldPassword)
                return false;
            user.Password = newPassword;
            Db.Users.Update(user);
            return true;
        }

        public void DeleteAccount(int userId)
        {
            User user = Db.Users.GetByID(userId);
            Db.Users.Delete(user);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
