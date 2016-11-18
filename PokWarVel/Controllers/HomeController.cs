using MarvelApi;
using MarvelApi.Model;
using PokWarVel.infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokWarVel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string page="")
        {
           
            if(page=="")
            {
                SessionUtil.offsetGal = 0;
            }
            else
            {
                if(page=="prev" && SessionUtil.offsetGal>12)
                {
                    SessionUtil.offsetGal -= 12;
                }
                
                if(page=="next")
                {
                    SessionUtil.offsetGal += 12;
                }
            }

            MarvelRequester r = new MarvelRequester();
            List<Characters> info = r.GetCharacters(limit: 12, offset: SessionUtil.offsetGal);

            return View(info);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}