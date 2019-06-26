using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.WebMVC.Controllers
{

                 //1
    public class NoteController : Controller
    {
         //2                  //3
        // GET: Note
        public ActionResult Index()
        {
                      //4
            return View();
        }
    }
}