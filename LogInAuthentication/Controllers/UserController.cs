using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogInAuthentication.Models;

namespace LogInAuthentication.Controllers
{
   
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: User
        public ActionResult Info()
        {
            var model = db.Users.Select(xx => new
            {
                User = xx.UserName,
                E_mail = xx.Email,
                Name = xx.FirstName,
                Date_Birth = xx.DateOfBirth
            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var model = db.Users.Select(xx => new
            {
                User = xx.UserName,
                E_mail = xx.Email,
                Name = xx.FirstName,
                Date_Birth = xx.DateOfBirth,
                Role = xx.Roles.ToList()
            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}