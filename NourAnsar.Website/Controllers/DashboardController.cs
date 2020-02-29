using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NourAnsar.Website.Data;
using NourAnsar.Website.Entities;
using NourAnsar.Website.Models;
using NourAnsar.Website.Repositories;
using NourAnsar.Website.ViewModels;

namespace NourAnsar.Website.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProjectRepository _projectRepository;

        public DashboardController(IProjectRepository projectRepository,
                                   ApplicationDbContext context)
        {
            _context = context;
            _projectRepository = projectRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects(int from, int to)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = await _projectRepository.All(from, to);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.Code = ex.GetHashCode().ToString();
            }
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetSearchProjects(string search,int from, int to)
        {
            ResponseResult result = new ResponseResult();
            try
            {
                result.Data = await _projectRepository.Search(search, from, to);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.Code = ex.GetHashCode().ToString();
            }
            return Json(result);
        }
    }
}