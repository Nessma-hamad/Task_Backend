﻿using BL.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();



        AccountRepository Account { get; }
    }
}
