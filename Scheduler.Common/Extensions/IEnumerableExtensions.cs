using System;
using System.Linq;
using System.Collections.Generic;
using Scheduler.Common.Repository;

namespace Scheduler.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static T GetRepository<T>(this IEnumerable<IRepository> _repos) where T: IRepository
            => (T)_repos.Where(repo => repo.GetType() == typeof(T)).FirstOrDefault();
    }
}