using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Guia4_DSE.Models;

namespace Guia4_DSE.Controllers
{
    public class AgendaController : ApiController
    {
        // GET api/TodoItem
        public IEnumerable<contacto> Get()
        {
            var db = new agenda();
            var listaItems = db.contacto.ToList();
            return listaItems;
        }
        // GET api/TodoItem/5
        public contacto Get(int id)
        {
            var db = new agenda();
            var item = db.contacto.Where(x => x.id == id).FirstOrDefault();
            return item;
        }
        // POST api/TodoItem
        public HttpResponseMessage Post([FromBody] contacto item)
        {
            var db = new agenda();
            db.contacto.Add(item);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, item,
           Configuration.Formatters.JsonFormatter);
        }
        // PUT api/TodoItem/5
        public HttpResponseMessage Put(int id, [FromBody] contacto item)
        {
            var db = new agenda();
            var tempItem = db.contacto.Where(x => x.id == id).FirstOrDefault();
            if (tempItem != null)
            {
                tempItem.nombre = item.nombre;
                tempItem.apellido = item.apellido;
                tempItem.celular = item.celular;
                tempItem.telefono = item.telefono;
                tempItem.correo = item.correo;
            }
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, tempItem,
           Configuration.Formatters.JsonFormatter);
        }
        // DELETE api/TodoItem/5
        public void Delete(int id)
        {
            var db = new agenda();
            var tempItem = db.contacto.Where(x => x.id == id).FirstOrDefault();
            if (tempItem != null)
            {
                db.contacto.Remove(tempItem);
            }
            db.SaveChanges();
        }
    }
}
