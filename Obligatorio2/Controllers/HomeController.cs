using Obligatorio2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Obligatorio2.Controllers
{
    public class HomeController : Controller
    {
        //probandoooooo

        Agencia a = Agencia.getInstancia();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Catalogo()
        {
            return View(a.getExcursiones());
        }

        
        
    }
}