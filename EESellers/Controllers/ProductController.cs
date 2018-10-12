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
    public class ProductController : ApiController
    {

        private EESellers.Models.DbContext db = new EESellers.Models.DbContext();

        //GET: api/Produtos
        public IHttpActionResult GetProdutos()
        {
            return Ok(db.Produtos.ToList());
        }


        //GET: api/Produtos/1
        public IHttpActionResult GetProduto(long id)
        {
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        // POST: api/Produtos
        [ResponseType(typeof(Produto))]
        public IHttpActionResult PostProduto(Produto produto)
        {
            db.Produtos.Add(produto);
            db.SaveChanges();

            return Ok(produto.cdProduto);
        }

        //PUT: api/Produtos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduto(long id, Produto produto)
        {

            if (id != produto.cdProduto)
            {
                return BadRequest();
            }

            db.Entry(produto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
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

        // DELETE: api/Produtos/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult DeleteProduto(long id)
        {
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            db.Produtos.Remove(produto);
            db.SaveChanges();

            return Ok(produto);
        }


        private bool ProdutoExists(long id)
        {
            return db.Produtos.Count(e => e.cdProduto == id) > 0;
        }
    }
}
