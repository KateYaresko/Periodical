using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminService : IAdminService
    {
        private IUnitOfWork Db { get; set; }
        public AdminService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public List<UserDTO> GetUsers()
        {
            Mapper.CreateMap<User, UserDTO>();
            return Mapper.Map<IEnumerable<User>, List<UserDTO>>(Db.Users.GetAll());
        }
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
