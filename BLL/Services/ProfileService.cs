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

namespace BLL.Services
{
    public class ProfileService : IProfileService
    {
        private IUnitOfWork Db { get; set; }
        public ProfileService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
