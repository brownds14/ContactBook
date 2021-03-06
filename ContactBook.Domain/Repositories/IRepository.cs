﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ContactBook.Domain
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> pred);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        void Reload(T entity);
    }
}
