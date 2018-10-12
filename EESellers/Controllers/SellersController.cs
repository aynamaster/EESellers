using EESellers.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;

namespace EESellers.Controllers
{
    public class SellersController : ApiController
    {
        private EESellers.Models.DbContext db = new EESellers.Models.DbContext();

        //GET: api/Sellers
        public IHttpActionResult GetVendedores()
        {
            return Ok(db.Vendedores.ToList());
        }


        //GET: api/Sellers/1
        public IHttpActionResult GetVendedor(long id)
        {
            Vendedor vendedor = db.Vendedores.Find(id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return Ok(vendedor);
        }

        // POST: api/Sellers
        [ResponseType(typeof(Vendedor))]
        public IHttpActionResult PostVendedor(Vendedor vendedor)
        {

            db.Vendedores.Add(vendedor);
            db.SaveChanges();

            return Ok(vendedor.id);
        }

        //PUT: api/Sellers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVendedor(long id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendedor.id)
            {
                return BadRequest();
            }

            db.Entry(vendedor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendedorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Sellers/5
        [ResponseType(typeof(Vendedor))]
        public IHttpActionResult DeleteVendedor(long id)
        {
            Vendedor vendedor = db.Vendedores.Find(id);
            if (vendedor == null)
            {
                return NotFound();
            }

            db.Vendedores.Remove(vendedor);
            db.SaveChanges();

            return Ok(vendedor);
        }


        private bool VendedorExists(long id)
        {
            return db.Vendedores.Count(e => e.id == id) > 0;
        }
    }
}
