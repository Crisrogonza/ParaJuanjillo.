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
	public class PrincipalController : ApiController
    {
        private ModeloPrincipal_ db = new ModeloPrincipal_();

        // GET: api/Principal
        public IQueryable<Principal> GetPrincipal()
        {
            return db.Principal;
        }

        // GET: api/Principal/5
        [ResponseType(typeof(Principal))]
        public async Task<IHttpActionResult> GetPrincipal(int id)
        {
            Principal principal = await db.Principal.FindAsync(id);
            if (principal == null)
            {
                return NotFound();
            }

            return Ok(principal);
        }

        // PUT: api/Principal/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrincipal(int id, Principal principal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != principal.Id_principal_)
            {
                return BadRequest();
            }

            db.Entry(principal).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrincipalExists(id))
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

        // POST: api/Principal
        [ResponseType(typeof(Principal))]
        public async Task<IHttpActionResult> PostPrincipal(Principal principal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Principal.Add(principal);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = principal.Id_principal_ }, principal);
        }

        // DELETE: api/Principal/5
        [ResponseType(typeof(Principal))]
        public async Task<IHttpActionResult> DeletePrincipal(int id)
        {
            Principal principal = await db.Principal.FindAsync(id);
            if (principal == null)
            {
                return NotFound();
            }

            db.Principal.Remove(principal);
            await db.SaveChangesAsync();

            return Ok(principal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrincipalExists(int id)
        {
            return db.Principal.Count(e => e.Id_principal_ == id) > 0;
        }
    }
}