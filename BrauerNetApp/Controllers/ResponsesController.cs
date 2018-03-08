using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BrauerNetApp.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty steps, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrauerNetApp.Controllers
{
    public class ResponsesController : Controller
    {
        private IResponseRepository responseRepo;

        public ResponsesController(IResponseRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.responseRepo = new EFResponseRepository();
            }
            else
            {
                this.responseRepo = thisRepo;
            }
        }

        public IActionResult Index()
        {
            var responsesList = responseRepo.Responses
                .ToList();

            return View(responsesList);
        }

        public IActionResult DetailsResponse(int id)
        {
            var theseResponses = responseRepo.Responses
                .Include(x => x.ProjectId == id);
            return View(theseResponses);
        }

        public IActionResult CreateResponse()
        {
            ViewBag.thisResponse = responseRepo.Responses;
            return View();
        }

        [HttpPost]
        public IActionResult CreateResponse(Response response)
        {
            responseRepo.Save(response);
            ViewBag.thisResponse = responseRepo.Responses
                .Include(p => p.Project)
                .ThenInclude(m => m.Module)
                .ThenInclude(q => q.QUESTOR)
                .FirstOrDefault(x => x.ResponseId == response.ResponseId);
            var thisStep = responseRepo.Responses.FirstOrDefault(x => x.ResponseId == response.ResponseId);
            return RedirectToAction("Edit", "QUESTORs", new { id = ViewBag.thisResponse.Project.Module.QUESTORId });
        }

        public IActionResult EditResponse(int id)
        {
            var thisResponse = responseRepo.Responses
                .Include(p => p.Project)
                .ThenInclude(m => m.Module)
                .ThenInclude(q => q.QUESTOR)
                .FirstOrDefault(x => x.ResponseId == id);
            return View(thisResponse);
        }

        [HttpPost]
        public IActionResult EditResponse(Response response)
        {
            responseRepo.Edit(response);
            ViewBag.thisResponse = responseRepo.Responses
                .Include(p => p.Project)
                .ThenInclude(m => m.Module)
                .ThenInclude(q => q.QUESTOR)
                .FirstOrDefault(x => x.ResponseId == response.ResponseId);
            return RedirectToAction("Edit", "QUESTORs", new { id = ViewBag.thisResponse.Project.Module.QUESTORId });
        }

        public IActionResult DeleteResponse(int id)
        {
            var thisResponse = responseRepo.Responses.FirstOrDefault(x => x.ResponseId == id);
            return View(thisResponse);
        }

        [HttpPost, ActionName("DeleteResponse")]
        public IActionResult DeleteConfirmed(int id)
        {
            ViewBag.thisResponse = responseRepo.Responses
                .Include(p => p.Project)
                .ThenInclude(m => m.Module)
                .ThenInclude(q => q.QUESTOR)
                .FirstOrDefault(x => x.ResponseId == id);
            var response = responseRepo.Responses.FirstOrDefault(x => x.ResponseId == id);
            Response thisResponse = responseRepo.Responses.FirstOrDefault(x => x.ResponseId == id);
            responseRepo.Remove(thisResponse);
            return RedirectToAction("Edit", "QUESTORs", new { id = ViewBag.thisResponse.Project.Module.QUESTORId });
        }
    }
}

