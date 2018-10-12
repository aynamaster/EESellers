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
    [Route("api/Sales")]
    public class SalesController : ApiController
    {
        private EESellers.Models.DbContext db = new EESellers.Models.DbContext();

        //GET: api/Sales
        public IHttpActionResult GetVendas()
        {
            return Ok(db.Vendas.ToList());
        }


        //GET: api/Sales/1
        public IHttpActionResult GetVenda(long id)
        {
            Vendas venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return NotFound();
            }

            return Ok(venda);
        }

        // POST: api/Sales
        [ResponseType(typeof(Vendas))]
        public IHttpActionResult PostVenda(Vendas venda)
        {
            Produto prod = db.Produtos.Find(venda.cdProduto);
            
            venda.vlrComissao =  prod.vlrUnitario*0.05;


            db.Vendas.Add(venda);
            db.SaveChanges();

            return Ok(venda.id);
        }

        //PUT: api/Sales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVenda(long id, Vendas venda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != venda.id)
            {
                return BadRequest();
            }

            db.Entry(venda).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendasExists(id))
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

        // DELETE: api/Sales/5
        [ResponseType(typeof(Vendas))]
        public IHttpActionResult DeleteVendas(long id)
        {
            Vendas venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return NotFound();
            }

            db.Vendas.Remove(venda);
            db.SaveChanges();

            return Ok(venda);
        }


        private bool VendasExists(long id)
        {
            return db.Vendas.Count(e => e.id == id) > 0;
        }
    }
}
