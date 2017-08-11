using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RiotGamesApi.Enums;
using RiotGamesApi.Libraries.Enums;
using RiotGamesApi.Libraries.Lol.Enums;
using RiotGamesApi.Libraries.Lol.v3.NonStaticEndPoints.ChampionMastery;
using RiotGamesApi.Libraries.Lol.v3.StaticEndPoints.Champions;
using RiotGamesApi.Models;

namespace RiotGamesApi.AspNet.Web.Controllers
{
    public class HomeController : Controller
    {
        private LolApi LolApi { get; set; }

        public HomeController()
        {
            LolApi = ApiSettings.GetService<LolApi>();
        }

        public async Task<ActionResult> Index()
        {
            var rit = await LolApi.NonStaticApi.ChampionMasteryv3.GetChampionMasteriesBySummonerAsync(ServicePlatform.EUW1, 34639237);
            if (rit.HasError)
            {
                throw rit.Exception;
            }
            return View(rit);
        }

        public ActionResult Items()
        {
            var rit = LolApi.StaticApi.StaticDatav3.GetItems(ServicePlatform.EUW1, true, null, null, new List<ItemTag>() { ItemTag.image, ItemTag.stats });
            if (rit.HasError)
            {
                throw rit.Exception;
            }
            return Json(rit.Result);
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