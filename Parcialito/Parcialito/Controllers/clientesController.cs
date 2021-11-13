using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Parcialito.Models;
using System.Text.RegularExpressions;

namespace Parcialito.Controllers
{
    public class clientesController : Controller
    {
        private tienditaModelo db = new tienditaModelo();

        // GET: clientes
        public ActionResult Index()
        {
            return View(db.cliente.ToList());
        }

        // GET: clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombreCliente,telefono,email,edad,DUI")] cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        /*
       CODIGOS DE ERROR
      0 Exitoso
      6  Vacio
      1 Nombre repetido
      2 DUI INVALIDO
      3 Nombre con numero invalido
      4 Telefono invalido
        5 Menor de edad

       */

        public static Regex regexNombreNum = new Regex(@"^[a-zA-Z]+(\s[a-zA-Z]+)?$");
        public static Regex regexTelInvalido = new Regex("^[0-9]{4}-[0-9]{4}$");
        public static Regex regexDUIinvalido = new Regex("^[0-9]{7}-[0-9]$");
        



        [HttpPost]
        public Int32 Agregar(cliente Cliente)
        {
            try
            {


                if (String.IsNullOrEmpty(Cliente.nombreCliente))
                    return 6;
                if (!regexDUIinvalido.IsMatch(Cliente.DUI))
                    return 2;
                if (!regexNombreNum.IsMatch(Cliente.nombreCliente))
                    return 3;
                if (!regexTelInvalido.IsMatch(Cliente.telefono))
                    return 4;
                if (Cliente.edad < 18)
                    return 5;


                return 0;
            }
            catch
            {
                return 1;
            }

        }

        // GET: clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombreCliente,telefono,email,edad,DUI")] cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cliente cliente = db.cliente.Find(id);
            db.cliente.Remove(cliente);
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
