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
            var service = CreateNoteService();

            if (service.CreateNote(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
            //NoteService service = CreateNoteService();

            //service.CreateNote(model);

            //return RedirectToAction("Index");
        }
        public ActionResult Details (int id)
        {
            var svc = CreateNoteService();
            var model = svc.GetNoteById(id);

            return View(model);
        }
        public ActionResult Edit (int id)
        {
            var service = CreateNoteService();
            var detail = service.GetNoteById(id);
            var model =
                new NoteEdit
                {
                    NoteID = detail.NoteID,
                    Title = detail.Title,
                    Content = detail.Content
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, NoteEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.NoteID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateNoteService();

            if (service.UpdateNote(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }
        private NoteService CreateNoteService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userID);
            return service;
        }
    }
}