using BasicTrelloImplementation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BasicTrelloImplementation.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var port = HttpContext.Connection.LocalPort;
            ViewData["port"] = port;
            return View();
        }

        [HttpPost]
        public IActionResult Authorise(string token)
        {
            if(!String.IsNullOrEmpty(token))
            {
                Trello.Token = token;
                return RedirectToAction(nameof(LoadBoards));
            }
            if(!String.IsNullOrEmpty(Trello.Token))
            {
                return RedirectToAction(nameof(LoadBoards));
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Boards()
        {
            return View(Trello.Boards);
        }

        public async Task<IActionResult> LoadBoards()
        {
            if (String.IsNullOrEmpty(Trello.Token))
            {
                return RedirectToAction(nameof(Index));
            }
            await Trello.LoadBoards();
            return RedirectToAction(nameof(Boards));
        }

        public IActionResult Cards()
        {
            if(Trello.Cards != null)
            {
                return View(Trello.Cards);
            }
            return View();
        }

        public async Task<IActionResult> LoadCards(string id)
        {
            if (String.IsNullOrEmpty(Trello.Token))
            {
                return RedirectToAction(nameof(Index));
            }
            await Trello.LoadCards(id);
            return RedirectToAction(nameof(Cards));
        }

        public IActionResult Comment(string id)
        {
            ViewData["CommentId"] = id;
            return View();
        }

        public async Task<IActionResult> AddComment(string id, string comment)
        {
            await Trello.AddComment(id, comment);
            return RedirectToAction(nameof(Cards));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
