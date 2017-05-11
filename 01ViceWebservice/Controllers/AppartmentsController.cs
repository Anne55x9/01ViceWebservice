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
using System.Web.Http.Description;
using _01ViceWebservice;

namespace _01ViceWebservice.Controllers
{
    public class AppartmentsController : ApiController
    {
        private TeamViceContext db = new TeamViceContext();

        // GET: api/Appartments
        public IQueryable<Appartment> GetAppartments()
        {
            return db.Appartments;
        }

        // GET: api/Appartments/5
        [ResponseType(typeof(Appartment))]
        public async Task<IHttpActionResult> GetAppartment(int id)
        {
            Appartment appartment = await db.Appartments.FindAsync(id);
            if (appartment == null)
            {
                return NotFound();
            }

            return Ok(appartment);
        }

        // PUT: api/Appartments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAppartment(int id, Appartment appartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appartment.AppartmentNo)
            {
                return BadRequest();
            }

            db.Entry(appartment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppartmentExists(id))
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

        // POST: api/Appartments
        [ResponseType(typeof(Appartment))]
        public async Task<IHttpActionResult> PostAppartment(Appartment appartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Appartments.Add(appartment);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AppartmentExists(appartment.AppartmentNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = appartment.AppartmentNo }, appartment);
        }

        // DELETE: api/Appartments/5
        [ResponseType(typeof(Appartment))]
        public async Task<IHttpActionResult> DeleteAppartment(int id)
        {
            Appartment appartment = await db.Appartments.FindAsync(id);
            if (appartment == null)
            {
                return NotFound();
            }

            db.Appartments.Remove(appartment);
            await db.SaveChangesAsync();

            return Ok(appartment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppartmentExists(int id)
        {
            return db.Appartments.Count(e => e.AppartmentNo == id) > 0;
        }
    }
}