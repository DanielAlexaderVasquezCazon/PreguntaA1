using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PreguntaA1.Models;

namespace PreguntaA1.Controllers
{
    public class vasquezsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/vasquezs
        [Authorize]
        public IQueryable<vasquez> Getvasquezs()
        {
            return db.vasquezs;
        }

        // GET: api/vasquezs/5
        [Authorize]
        [ResponseType(typeof(vasquez))]
        public IHttpActionResult Getvasquez(int id)
        {
            vasquez vasquez = db.vasquezs.Find(id);
            if (vasquez == null)
            {
                return NotFound();
            }

            return Ok(vasquez);
        }

        // PUT: api/vasquezs/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Putvasquez(int id, vasquez vasquez)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vasquez.vasquezID)
            {
                return BadRequest();
            }

            db.Entry(vasquez).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vasquezExists(id))
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

        // POST: api/vasquezs
        [Authorize]
        [ResponseType(typeof(vasquez))]
        public IHttpActionResult Postvasquez(vasquez vasquez)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vasquezs.Add(vasquez);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vasquez.vasquezID }, vasquez);
        }

        // DELETE: api/vasquezs/5
        [Authorize]
        [ResponseType(typeof(vasquez))]
        public IHttpActionResult Deletevasquez(int id)
        {
            vasquez vasquez = db.vasquezs.Find(id);
            if (vasquez == null)
            {
                return NotFound();
            }

            db.vasquezs.Remove(vasquez);
            db.SaveChanges();

            return Ok(vasquez);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vasquezExists(int id)
        {
            return db.vasquezs.Count(e => e.vasquezID == id) > 0;
        }
    }
}