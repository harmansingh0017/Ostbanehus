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
    public class ApartmentsController : ApiController
    {
        private osttbanehus db = new osttbanehus();

        // GET: api/Apartments
        public IQueryable<Apartment> GetApartments()
        {
            return db.Apartments;
        }

        // GET: api/Apartments/5
        [ResponseType(typeof(Apartment))]
        public IHttpActionResult GetApartment(int id)
        {
            Apartment apartment = db.Apartments.Find(id);
            if (apartment == null)
            {
                return NotFound();
            }

            return Ok(apartment);
        }

        // PUT: api/Apartments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApartment(int id, Apartment apartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apartment.Apartment_No)
            {
                return BadRequest();
            }

            db.Entry(apartment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmentExists(id))
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

        // POST: api/Apartments
        [ResponseType(typeof(Apartment))]
        public IHttpActionResult PostApartment(Apartment apartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Apartments.Add(apartment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ApartmentExists(apartment.Apartment_No))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = apartment.Apartment_No }, apartment);
        }

        // DELETE: api/Apartments/5
        [ResponseType(typeof(Apartment))]
        public IHttpActionResult DeleteApartment(int id)
        {
            Apartment apartment = db.Apartments.Find(id);
            if (apartment == null)
            {
                return NotFound();
            }

            db.Apartments.Remove(apartment);
            db.SaveChanges();

            return Ok(apartment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApartmentExists(int id)
        {
            return db.Apartments.Count(e => e.Apartment_No == id) > 0;
        }
    }
}