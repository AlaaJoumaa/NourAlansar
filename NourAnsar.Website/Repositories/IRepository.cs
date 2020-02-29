using NourAnsar.Website.Data;
using NourAnsar.Website.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NourAnsar.Website.Repositories
{
    public interface IRepository<T>
    {
        Task<RepositoryVM> Add(T model);
        Task<RepositoryVM> Edit(T model);
        Task<RepositoryVM> Save(T model);
        Task<RepositoryVM> All(int from,int to);
    }
}
