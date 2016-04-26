﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chloe.Core
{
    public interface IGroupingQuery<T>
    {
        IGroupingQuery<T> ThenBy<K>(Expression<Func<T, K>> predicate);
        IGroupingQuery<T> Having(Expression<Func<T, bool>> predicate);
        IQuery<TResult> Select<TResult>(Expression<Func<T, TResult>> selector);
    }
}