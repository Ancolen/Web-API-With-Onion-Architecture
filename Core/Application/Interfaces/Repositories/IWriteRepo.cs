﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IWriteRepo<T> where T : class, IEntityBase, new()
    {
        Task      AddAsync      (T        entity);
        Task      AddRangeAsync (IList<T> entities);
        Task<T>   UpdateAsync   (T        entity);
        Task      DeleteAsync   (T        entity);

    }
}
