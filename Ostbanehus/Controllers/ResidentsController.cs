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
using Ostbanehus.Models;

namespace Ostbanehus.Controllers
{
    public class ResidentsController : ApiController
    {
        private osttbanehus db = new osttbanehus();

        // GET: api/Residents
        public IQueryable<Resident> GetResidents()
        {
            return db.Residents;
        }

        // GET: api/Residents/5
        [ResponseType(typeof(Resident))]
        public IHttpActionResult GetResident(int id)
        {
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return NotFound();
            }

            return Ok(resident);
        }

        // PUT: api/Residents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResident(int id, Resident resident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resident.Resident_No)
            {
                return BadRequest();
            }

            db.Entry(resident).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidentExists(id))
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

        // POST: api/Residents
        [ResponseType(typeof(Resident))]
        public IHttpActionResult PostResident(Resident resident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Residents.Add(resident);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = resident.Resident_No }, resident);
        }

        // DELETE: api/Residents/5
        [ResponseType(typeof(Resident))]
        public IHttpActionResult DeleteResident(int id)
        {
            Resident resident = db.Residents.Find(id);
            if (resident == null)
            {
                return NotFound();
            }

            db.Residents.Remove(resident);
            db.SaveChanges();

            return Ok(resident);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResidentExists(int id)
        {
            return db.Residents.Count(e => e.Resident_No == id) > 0;
        }
    }
}