using Microsoft.AspNetCore.Mvc;
using lab.OCRSample.Helpers;
using lab.OCRSample.Models;
using System.Diagnostics;

namespace lab.OCRSample.Controllers
{
    public class BaseController : Controller
    {

        internal IActionResult ErrorView(Exception ex)
        {
            var errorViewModel = new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorType = MessageHelper.MessageTypeDanger, ErrorMessage = MessageHelper.Error };
            return View("~/Views/Shared/Error.cshtml", errorViewModel);
        }

        internal IActionResult ErrorPartialView(Exception ex)
        {
            var errorViewModel = new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,  ErrorType = MessageHelper.MessageTypeDanger, ErrorMessage = MessageHelper.Error };
            return PartialView("~/Views/Shared/_Error.cshtml", errorViewModel);
        }

        internal IActionResult ErrorNullView()
        {
            var errorViewModel = new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,  ErrorType = MessageHelper.Info, ErrorMessage = MessageHelper.NullError };
            return View("~/Views/Shared/Error.cshtml", errorViewModel);
        }

        internal IActionResult ErrorNullPartialView()
        {
            var errorViewModel = new ErrorViewModel() { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,  ErrorType = MessageHelper.Info, ErrorMessage = MessageHelper.NullError };
            return PartialView("~/Views/Shared/_Error.cshtml", errorViewModel);
        }

    }
}
