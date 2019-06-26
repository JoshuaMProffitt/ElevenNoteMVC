using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.WebMVC.Controllers
{

                 //1
    [Authorize]
    public class NoteController : Controller
    {
        //2                  //3
        // GET: Note
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var Service = new NoteService(userID);
            var model = Service.GetNotes();

            return View(model);
        }
        //add method here vvvvvvvvvv
        //get
        public ActionResult Create()
        {
            return View();
        }
        //Added code here vvvv
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NoteCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userID);

            service.CreateNote(model);

            return RedirectToAction("Index");
        }
    }
}