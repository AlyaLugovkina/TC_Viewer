﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcModels.Models.Interfaces
{
    public interface ICache<T>
    {
        void Add(string key, T value);
        T Get(string key);
    }
}
