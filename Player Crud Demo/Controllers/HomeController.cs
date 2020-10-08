using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using Player_Crud_Demo.Models;

namespace Player_Crud_Demo.Controllers
{
    public class HomeController : Controller
    {
        Database.db dbLayer = new Database.db();

        public ActionResult ShowPlayerList()
        {
            DataSet ds = dbLayer.ShowPlyerList();
            ViewBag.player = ds.Tables[0];

            return View();
        }

        public ActionResult InsertPlayer()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult InsertPlayer(FormCollection fc)
        {
            PlayerClass pl = new PlayerClass();
            pl.FirstName = fc["FirstName"];
            pl.LastName = fc["LastName"];
            pl.Email = fc["Email"];

            dbLayer.AddPlayer(pl);
            TempData["msg"] = "Insertion Successful";
            return View();
        }
    }
}
