using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ApiPeliculasFinalEstasi.Models;

namespace ApiPeliculasFinalEstasi.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class ProductoraController : ApiController
    {
        private ModeloPrincipal_ db = new ModeloPrincipal_();

        // GET: api/Productora
        public IQueryable<Productora> GetProductora()
        {
            return db.Productora;
        }

        // GET: api/Productora/5
        [ResponseType(typeof(Productora))]
        public async Task<IHttpActionResult> GetProductora(int id)
        {
            Productora productora = await db.Productora.FindAsync(id);
            if (productora == null)
            {
                return NotFound();
            }

            return Ok(productora);
        }

        // PUT: api/Productora/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductora(int id, Productora productora)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productora.Id_productora)
            {
                return BadRequest();
            }

            db.Entry(productora).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoraExists(id))
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

        // POST: api/Productora
        [ResponseType(typeof(Productora))]
        public async Task<IHttpActionResult> PostProductora(Productora productora)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Productora.Add(productora);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productora.Id_productora }, productora);
        }

        // DELETE: api/Productora/5
        [ResponseType(typeof(Productora))]
        public async Task<IHttpActionResult> DeleteProductora(int id)
        {
            Productora productora = await db.Productora.FindAsync(id);
            if (productora == null)
            {
                return NotFound();
            }

            db.Productora.Remove(productora);
            await db.SaveChangesAsync();

            return Ok(productora);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductoraExists(int id)
        {
            return db.Productora.Count(e => e.Id_productora == id) > 0;
        }
    }
}