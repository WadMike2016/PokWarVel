﻿using PokWarVel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokWarVel.Controllers
{
    public class GmapController : Controller
    {
        // GET: Gmap
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult TopFiveCoords()
        {

            List<JsonGeoModel> lm = JsonGeoModel.GetTopFiveWithLoc();
            return Json(lm, JsonRequestBehavior.AllowGet);
        }
    }
}