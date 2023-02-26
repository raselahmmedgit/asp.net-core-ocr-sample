using lab.OCRSample.Managers;
using lab.OCRSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace lab.OCRSample.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _iLogger;
        private readonly IDataManager _iDataManager;

        public HomeController(ILogger<HomeController> iLogger, IDataManager iDataManager)
        {
            _iLogger = iLogger;
            _iDataManager = iDataManager;
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}