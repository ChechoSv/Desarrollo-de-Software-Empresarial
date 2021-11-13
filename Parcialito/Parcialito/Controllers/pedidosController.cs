using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Parcialito.Models;

namespace Parcialito.Controllers
{
    public class pedidosController : Controller
    {
        private tienditaModelo db = new tienditaModelo();

        // GET: pedidos
        public ActionResult Index()
        {
            var pedidos = db.pedidos.Include(p => p.cliente).Include(p => p.producto);
            return View(pedidos.ToList());
        }

        // GET: pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // GET: pedidos/Create
        public ActionResult Create()
        {
            ViewBag.idCliente = new SelectList(db.cliente, "id", "nombreCliente");
            ViewBag.idProducto = new SelectList(db.producto, "id", "nombreProducto");
            return View();
        }

        // POST: pedidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idCliente,idProducto,cantidad,fecha")] pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                db.pedidos.Add(pedidos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.cliente, "id", "nombreCliente", pedidos.idCliente);
            ViewBag.idProducto = new SelectList(db.producto, "id", "nombreProducto", pedidos.idProducto);
            return View(pedidos);
        }

        // GET: pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCliente = new SelectList(db.cliente, "id", "nombreCliente", pedidos.idCliente);
            ViewBag.idProducto = new SelectList(db.producto, "id", "nombreProducto", pedidos.idProducto);
            return View(pedidos);
        }

        // POST: pedidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idCliente,idProducto,cantidad,fecha")] pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCliente = new SelectList(db.cliente, "id", "nombreCliente", pedidos.idCliente);
            ViewBag.idProducto = new SelectList(db.producto, "id", "nombreProducto", pedidos.idProducto);
            return View(pedidos);
        }

        // GET: pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pedidos pedidos = db.pedidos.Find(id);
            if (pedidos == null)
            {
                return HttpNotFound();
            }
            return View(pedidos);
        }

        // POST: pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pedidos pedidos = db.pedidos.Find(id);
            db.pedidos.Remove(pedidos);
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
