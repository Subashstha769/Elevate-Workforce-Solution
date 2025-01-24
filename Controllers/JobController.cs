using AspNetCoreGeneratedDocument;
using ISMT23CWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using WebLab2024.Interfaces;

namespace WebLab2024.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        private readonly IJobRepository _jobRepository;

        public JobController(IJobRepository jobRepository)

        {

            _jobRepository = jobRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(JobViewModel jvm)
        {
            jvm.AddedById = Convert.ToInt32(HttpContext.User.Claims.ElementAt(1).Value);
            var result = _jobRepository.Create(jvm);

            Console.WriteLine("Result ==>" + result);
            if (result)
            {

                return RedirectToAction("List");

            }
            return View();
        }
        // public IActionResult List(int CurrentPage = 1, int PageSize = 10)
        // {
        //     var jobs = _jobRepository.GetAll();
        //     if (jobs.Any())
        //     {
        //         var paged_list = jobs.OrderBy(x => x.Id).Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

        //         var result = new PaginatedJobViewModel()
        //         {
        //             CurrentPage = 1,
        //             Count = jobs.Count,
        //             Data = paged_list
        //         };
        //         return View(result);
        //     }
        //     return View(Enumerable.Empty<PaginatedJobViewModel>());
        // }

        public IActionResult List(int CurrentPage = 1, int PageSize = 10)
        {
            var jobs = _jobRepository.GetAll();
            if (jobs.Any())
            {
                var paged_list = jobs.OrderBy(x => x.Id)
                                     .Skip((CurrentPage - 1) * PageSize)
                                     .Take(PageSize)
                                     .ToList();

                // Assigning sequential display order
                for (int i = 0; i < paged_list.Count; i++)
                {
                    paged_list[i].DisplayOrder = (CurrentPage - 1) * PageSize + i + 1;
                }

                var result = new PaginatedJobViewModel()
                {
                    CurrentPage = CurrentPage,
                    Count = jobs.Count,
                    Data = paged_list
                };
                return View(result);
            }
            return View(Enumerable.Empty<PaginatedJobViewModel>());
        }

        public IActionResult Edit(int id)
        {
            var result = _jobRepository.GetById(id);

            if (result != null)
            {
                return View(result);
            }

            return RedirectToAction("List");
        }

        [HttpPost]

        public IActionResult Edit(int id, JobViewModel jvm)
        {
            jvm.Id = id;
            jvm.AddedById = Convert.ToInt32(HttpContext.User.Claims.ElementAt(1).Value);

            var result = _jobRepository.Update(jvm);

            if (result)
            {
                return RedirectToAction("List");
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            var result = _jobRepository.GetById(id);
            return View(result);
        }

        public IActionResult Delete(int id)
        {
            var result = _jobRepository.GetById(id);
            return View(result);
        }

        [HttpPost]

        public IActionResult Delete(int id, JobViewModel jvm)
        {
            jvm.Id = id;
            var result = _jobRepository.Delete(jvm);
            return RedirectToAction("List");
        }
        [AllowAnonymous]
        public IActionResult Opportunities(int CurrentPage = 1, int PageSize = 10)
        {
            var jobs = _jobRepository.GetAll();
            if (jobs.Any())
            {
                var paged_list = jobs.OrderBy(x => x.Id)
                                     .Skip((CurrentPage - 1) * PageSize)
                                     .Take(PageSize)
                                     .ToList();

                // Assigning sequential display order
                for (int i = 0; i < paged_list.Count; i++)
                {
                    paged_list[i].DisplayOrder = (CurrentPage - 1) * PageSize + i + 1;
                }

                var result = new PaginatedJobViewModel()
                {
                    CurrentPage = CurrentPage,
                    Count = jobs.Count,
                    Data = paged_list
                };
                return View(result);
            }
            return View(Enumerable.Empty<PaginatedJobViewModel>());
        }






    }
}