﻿using System;
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
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork Db { get; set; }
        public AccountService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public List<UserDTO> GetUserByEmail(string email)
        {
            Mapper.CreateMap<User, UserDTO>();
            return Mapper.Map<IEnumerable<User>, List<UserDTO>>(Db.Users.GetBy(user => user.Email == email));
        }
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}