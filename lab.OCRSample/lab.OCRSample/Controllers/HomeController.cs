using lab.OCRSample.Managers;
using lab.OCRSample.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace lab.OCRSample.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _iLogger;
        private readonly IDataManager _iDataManager;
        private readonly IWebHostEnvironment _iWebHostEnvironment;

        public HomeController(ILogger<HomeController> iLogger, IDataManager iDataManager, IWebHostEnvironment iWebHostEnvironment)
        {
            _iLogger = iLogger;
            _iDataManager = iDataManager;
            _iWebHostEnvironment = iWebHostEnvironment;
        }

        public IActionResult Index()
        {
            try
            {
                var homeViewModel = new HomeViewModel()
                {
                };

                return View(homeViewModel);
            }
            catch (Exception ex)
            {
                _iLogger.LogError(ex, "HomeController - Task<IActionResult> Index()");
                return ErrorView(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EmguCVOCRFileUpload(HomeViewModel model)
        {
            try
            {
                model.SubFolderName = "EmguCVOCR";
                var reult = await _iDataManager.UploadEmguCVOCR(model);

                if (reult)
                {

                    return View(model);
                }
                else
                {
                    return ErrorNullPartialView();
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogError(ex, "HomeController - Task<IActionResult> EmguCVOCRFileUpload(HomeViewModel model)");
                return ErrorView(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GoogleVisionOCRFileUpload(HomeViewModel model)
        {
            try
            {
                model.SubFolderName = "GoogleVisionOCR";
                var reult = await _iDataManager.UploadGoogleVisionOCR(model);

                if (reult)
                {

                    return View(model);
                }
                else
                {
                    return ErrorNullPartialView();
                }
            }
            catch (Exception ex)
            {
                _iLogger.LogError(ex, "HomeController - Task<IActionResult> GoogleVisionOCRFileUpload(HomeViewModel model)");
                return ErrorView(ex);
            }
        }

        public IActionResult EmguCVOCR()
        {
            try
            {
                var provider = new PhysicalFileProvider(_iWebHostEnvironment.WebRootPath);
                var contents = provider.GetDirectoryContents(Path.Combine("img"));
                var objFiles = contents.OrderBy(m => m.LastModified);

                List<string> fileList = new List<string>();
                foreach (var item in objFiles.ToList())
                {
                    fileList.Add(item.Name);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _iLogger.LogError(ex, "HomeController - Task<IActionResult> EmguCVOCR()");
                return ErrorView(ex);
            }
        }

        public IActionResult GoogleVisionOCR()
        {
            try
            {
                var provider = new PhysicalFileProvider(_iWebHostEnvironment.WebRootPath);
                var contents = provider.GetDirectoryContents(Path.Combine("img"));
                var objFiles = contents.OrderBy(m => m.LastModified);

                List<string> fileList = new List<string>();
                foreach (var item in objFiles.ToList())
                {
                    fileList.Add(item.Name);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _iLogger.LogError(ex, "HomeController - Task<IActionResult> GoogleVisionOCR()");
                return ErrorView(ex);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}