using PokWarVel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokWarVel.Controllers
{
    public class HeroController : Controller
    {
        // GET: Hero
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// get Evals view for the specified hero.
        /// </summary>
        /// <param name="idHero">The hero's id.</param>
        /// <returns>The view</returns>
        public ActionResult Eval(long id)
        {
            EvalViewModel ev = new Models.EvalViewModel();
            ev.Evm = new EvalModel() { IdHero = id };
            ev.Rm = ResultModel.GetOne(id, ResultModel.Etype.Marvel);


            return View(ev);
        }

        [HttpPost]
        public ActionResult Eval(EvalViewModel Ev)
        {
            if(Ev.Evm.Save())
            {
                ViewBag.Msg = "Enregistré";
            }
            else
            {
                ViewBag.Error = "Erreur lors de l'enregistrement";
            }
            Ev.Rm = ResultModel.GetOne(Ev.Evm.IdHero, ResultModel.Etype.Marvel);


            return View(Ev);
        }
    }
}