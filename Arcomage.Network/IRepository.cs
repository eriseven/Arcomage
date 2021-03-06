﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network
{
    public interface IRepository<T>
        where T : Entity
    {
        Task<T> GetById(Guid id);

        Task<bool> DeleteById(Guid id);

        Task<bool> Add(T entity);

        Task<bool> Save(T entity);

        Task<bool> Update(T entity, Action<T> update);
    }
}
