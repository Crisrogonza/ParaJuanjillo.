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
	public class DirectorController : ApiController
    {
        private ModeloPrincipal_ db = new ModeloPrincipal_();

        // GET: api/Director
        public IQueryable<Director> GetDirector()
        {
            return db.Director;
        }

        // GET: api/Director/5
        [ResponseType(typeof(Director))]
        public async Task<IHttpActionResult> GetDirector(int id)
        {
            Director director = await db.Director.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }

            return Ok(director);
        }

        // PUT: api/Director/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDirector(int id, Director director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != director.Id_Director)
            {
                return BadRequest();
            }

            db.Entry(director).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(id))
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

        // POST: api/Director
        [ResponseType(typeof(Director))]
        public async Task<IHttpActionResult> PostDirector(Director director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Director.Add(director);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = director.Id_Director }, director);
        }

        // DELETE: api/Director/5
        [ResponseType(typeof(Director))]
        public async Task<IHttpActionResult> DeleteDirector(int id)
        {
            Director director = await db.Director.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }

            db.Director.Remove(director);
            await db.SaveChangesAsync();

            return Ok(director);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DirectorExists(int id)
        {
            return db.Director.Count(e => e.Id_Director == id) > 0;
        }
    }
}