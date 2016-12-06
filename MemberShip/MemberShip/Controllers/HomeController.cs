using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MemberShip.Models;

namespace MemberShip.Controllers
{

    public class HomeController : Controller
    {

        private Test db = new Test();
        
        //
        // GET: /Home/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.UserProfile.ToList());
        }

        [Authorize]
        public ActionResult Details(int? id)
        {
            UserProfile user = db.UserProfile.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /Default/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(UserProfile user)
        {
            if (ModelState.IsValid)
            {
                db.UserProfile.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        //
        // GET: /Default/Edit
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            UserProfile user = db.UserProfile.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Default/Edit
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(UserProfile user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /Default/Delete
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            UserProfile user = db.UserProfile.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Default/Delete
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(UserProfile user)
        {
            if (ModelState.IsValid)
            {
                db.UserProfile.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }
    }
}
