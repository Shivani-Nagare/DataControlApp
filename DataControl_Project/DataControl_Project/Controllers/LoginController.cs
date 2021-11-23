using DataControl_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataControl_Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(DataControl_Project.Models.tbl_UserLogin userModel)
        {
            using (FriendDBEntities db = new FriendDBEntities())
            {
                var userDetails = db.tbl_UserLogin.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
                if(userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password.";
                    return View("Index", userModel);
                }
                else
                {
                    Session["UserID"] = userDetails.UserId;
                    return RedirectToAction("Index", "tblLocations");
                }
            }
        }
    }
}