using Microsoft.EntityFrameworkCore;
using NourAnsar.Website.Data;
using NourAnsar.Website.Models;
using NourAnsar.Website.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NourAnsar.Website.Repositories
{
    public interface IProjectRepository:IRepository<Project>
    {
        Task<RepositoryVM> Search(string search, int from, int to);
    }

    public class ProjectRepository : Repository, IProjectRepository
    {

        public ProjectRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<RepositoryVM> Add(Project model)
        {
            throw new NotImplementedException();
        }

        public async Task<RepositoryVM> All(int from, int to)
        {
            return await Task.Run(() =>
            {
                RepositoryVM repositoryVM = new RepositoryVM();
                repositoryVM.Result = Context.Projects.Skip(from).Take(to).ToList();
                repositoryVM.Success = true;
                return repositoryVM;
            });
        }

        public async Task<RepositoryVM> Edit(Project model)
        {
            throw new NotImplementedException();
        }

        public async Task<RepositoryVM> Save(Project model)
        {
            throw new NotImplementedException();
        }

        public async Task<RepositoryVM> Search(string search, int from, int to)
        {
            return await Task.Run(() =>
            {
                RepositoryVM repositoryVM = new RepositoryVM();
                Expression<Func<Project,bool>> searchExp = x => (search.Contains(x.Title) || search.Contains(x.Description)) || string.IsNullOrEmpty(search);
                repositoryVM.Result = Context.Projects.Where(searchExp).Skip(from).Take(to).ToList();
                repositoryVM.Success = true;
                return repositoryVM;
            });
        }
    }
}
