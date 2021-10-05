using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Biblioteca.Models;

namespace MVC_Biblioteca.Controllers
{
    public class prestamoesController : Controller
    {
        private biblioteca db = new biblioteca();

        // GET: prestamoes
        public ActionResult Index()
        {
         
            return View(db.prestamo.ToList());

        }

        // GET: prestamoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamo prestamo = db.prestamo.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // GET: prestamoes/Create
        public ActionResult Create()
        {
            DropDownListStudents();
            return View();
        }

        private void DropDownListStudents(object selectedStudent = null)
        {
            var departmentsQuery = from d in db.estudiante
                                   orderby d.nombre
                                   
                                   select d;
            ViewBag.StudentID = new SelectList(departmentsQuery, "id", "nombre", selectedStudent);
        }

        // POST: prestamoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fechaPrestamo,fechaDevolucion,estudiante_id,libro_id")] prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.prestamo.Add(prestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prestamo);
        }

        // GET: prestamoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamo prestamo = db.prestamo.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // POST: prestamoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fechaPrestamo,fechaDevolucion,estudiante_id,libro_id")] prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prestamo);
        }

        // GET: prestamoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamo prestamo = db.prestamo.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // POST: prestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            prestamo prestamo = db.prestamo.Find(id);
            db.prestamo.Remove(prestamo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
