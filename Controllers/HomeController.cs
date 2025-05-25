using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MSCodeworks.Web.Models;

namespace MSCodeworks.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Projects()
        {
            var projects = new List<Project>
    {
        new Project
        {
            Title = "Punjab State Lotteries Portal",
            Description = "Contributed to backend development and technical support using ASP.NET MVC and SQL Server.",
            ImageUrl = "~/img/projects/PunjabStateLottery.jpg",
            DetailUrl = "https://punjabstatelotteries.gov.in",
            Category = "Web"
        },
        new Project
        {
            Title = "BOCW Punjab Portal",
            Description = "Assisted in developing and maintaining the worker registration portal using ASP.NET Core MVC.",
            ImageUrl = "~/img/projects/BOCWWebSite.jpg",
            DetailUrl = "https://bocw.punjab.gov.in/bocwstatic/",
            Category = "Web"
        },
        new Project
        {
            Title = "Vehicle Management System (VMS)",
            Description = "Involved in backend module development and data management for the VMS portal used across Punjab government offices.",
            ImageUrl = "~/img/projects/VMSWebsite.jpg",
            DetailUrl = "https://vms.punjab.gov.in/",
            Category = "App"
        },
        new Project
        {
            Title = "GPMS Punjab Portal",
            Description = "Worked on Government Project Monitoring System for real-time tracking of projects.",
            ImageUrl = "~/img/projects/GPMSWebSite.jpg",
            DetailUrl = "https://gpms.punjab.gov.in/",
            Category = "Web"
        },
        new Project
        {
            Title = "PIRA Punjab Portal",
            Description = "Assisted in developing the Punjab Infrastructure Regulatory Authority portal.",
            ImageUrl = "~/img/projects/PIRAWebsite.jpg",
            DetailUrl = "https://pira.punjab.gov.in/",
            Category = "Web"
        },
        new Project
        {
            Title = "IFMS Punjab",
            Description = "Developed SSRS reports for Budget, Treasury, and Receipt modules. Enhanced financial tracking and reporting capabilities.",
            ImageUrl = "~/img/projects/IFMSWebsite.jpg",
            DetailUrl = "https://ifms.punjab.gov.in/",
            Category = "App"
        }
    };

            return View(projects);
        }


        public IActionResult Team()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UploadCV()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadCV(IFormFile cvFile)
        {
            if (cvFile != null && cvFile.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", cvFile.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await cvFile.CopyToAsync(stream);
                }

                ViewBag.Message = "CV uploaded successfully!";
            }
            else
            {
                ViewBag.Message = "Please select a valid file.";
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Resume()
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resume/Manpreet_Singh_CV.pdf");
            var bytes = System.IO.File.ReadAllBytes(filepath);
            return File(bytes, "application/pdf");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

