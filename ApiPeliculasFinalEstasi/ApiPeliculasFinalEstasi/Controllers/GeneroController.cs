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
	public class GeneroController : ApiController
    {
        private ModeloPrincipal_ db = new ModeloPrincipal_();

        // GET: api/Genero
        public IQueryable<Genero> GetGenero()
        {
            return db.Genero;
        }

        // GET: api/Genero/5
        [ResponseType(typeof(Genero))]
        public async Task<IHttpActionResult> GetGenero(int id)
        {
            Genero genero = await db.Genero.FindAsync(id);
            if (genero == null)
            {
                return NotFound();
            }

            return Ok(genero);
        }

        // PUT: api/Genero/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGenero(int id, Genero genero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genero.Id_genero)
            {
                return BadRequest();
            }

            db.Entry(genero).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneroExists(id))
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

        // POST: api/Genero
        [ResponseType(typeof(Genero))]
        public async Task<IHttpActionResult> PostGenero(Genero genero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Genero.Add(genero);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = genero.Id_genero }, genero);
        }

        // DELETE: api/Genero/5
        [ResponseType(typeof(Genero))]
        public async Task<IHttpActionResult> DeleteGenero(int id)
        {
            Genero genero = await db.Genero.FindAsync(id);
            if (genero == null)
            {
                return NotFound();
            }

            db.Genero.Remove(genero);
            await db.SaveChangesAsync();

            return Ok(genero);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GeneroExists(int id)
        {
            return db.Genero.Count(e => e.Id_genero == id) > 0;
        }
    }
}