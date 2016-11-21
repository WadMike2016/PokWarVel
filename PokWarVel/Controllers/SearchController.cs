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
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return RedirectToActionPermanent("Index", "Home");
        }

        [HttpPost]
        public ActionResult Results(string Search, string page="")
        {
            if (page == "")
            {
                SessionUtil.offsetGalSearch = 0;
            }
            else
            {
                if (page == "prev" && SessionUtil.offsetGalSearch > 12)
                {
                    SessionUtil.offsetGalSearch -= 12;
                }

                if (page == "next")
                {
                    SessionUtil.offsetGalSearch += 12;
                }
            }

            MarvelRequester r = new MarvelRequester();
            List<Characters> info = r.SearchCharacters(limit: 12, offset: SessionUtil.offsetGal, SearchString:Search);


            ViewBag.searchword = Search;
            return View(info.Select(i=>Mapper.FromMarvelToLocal(i)).ToList());
        }
    }
}