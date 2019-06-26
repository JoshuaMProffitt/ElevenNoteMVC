using ElevenNote.WebMVC.Models;
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
            //4
            var model = new NoteListItem[0];
            return View();
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}