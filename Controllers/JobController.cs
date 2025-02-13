using AspNetCoreGeneratedDocument;
using ISMT23CWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using WebLab2024.Interfaces;

namespace WebLab2024.Controllers
{
    // Ensures that only authorized users can access this controller

    [Authorize]
    public class JobController : Controller
    {
        private readonly IJobRepository _jobRepository;

        // Constructor to initialize the job repository

        public JobController(IJobRepository jobRepository)

        {

            _jobRepository = jobRepository;
        }

        // Displays the main job index page
        public IActionResult Index()
        {
            return View();
        }

        // Displays the job creation form
        public IActionResult Create()
        {
            return View();
        }

        // Handles the job creation request
        [HttpPost]
        public IActionResult Create(JobViewModel jvm)
        {
            // Assigns the ID of the user who added the job

            jvm.AddedById = Convert.ToInt32(HttpContext.User.Claims.ElementAt(1).Value);
            var result = _jobRepository.Create(jvm);

            Console.WriteLine("Result ==>" + result);
            if (result)
            {

                return RedirectToAction("List");

            }
            return View();
        }

        // Displays a paginated list of jobs
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

        // Displays the edit form for a specific job

        public IActionResult Edit(int id)
        {
            var result = _jobRepository.GetById(id);

            if (result != null)
            {
                return View(result);
            }

            return RedirectToAction("List");
        }

        // Handles the job update request

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
        // Displays details of a specific job
        public IActionResult Details(int id)
        {
            var result = _jobRepository.GetById(id);
            return View(result);
        }
        // Displays the delete confirmation page
        public IActionResult Delete(int id)
        {
            var result = _jobRepository.GetById(id);
            return View(result);
        }

        // Handles the job deletion request
        [HttpPost]

        public IActionResult Delete(int id, JobViewModel jvm)
        {
            jvm.Id = id;
            var result = _jobRepository.Delete(jvm);
            return RedirectToAction("List");
        }
         // Displays job opportunities (public access allowed)
         
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