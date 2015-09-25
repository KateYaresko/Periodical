﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        void UpdateUser(int userId, int editionId);
    }
}
