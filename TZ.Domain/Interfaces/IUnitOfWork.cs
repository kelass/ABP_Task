﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Domain.DbModels;

namespace TZ.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<Experiment> Experiments { get; }
    }
}
