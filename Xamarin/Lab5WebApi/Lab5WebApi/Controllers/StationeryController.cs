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
using Lab5WebApi.Models;

namespace Lab5WebApi.Controllers
{
    public class StationeryController : ApiController
    {
        private StationeryContext db = new StationeryContext();

        // GET: api/Stationery
        public IQueryable<Stationery> GetStationerySet()
        {
            return db.StationerySet;
        }

        // GET: api/Stationery/5
        [ResponseType(typeof(Stationery))]
        public IHttpActionResult GetStationery(int id)
        {
            Stationery stationery = db.StationerySet.Find(id);
            if (stationery == null)
            {
                return NotFound();
            }

            return Ok(stationery);
        }

        // PUT: api/Stationery/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStationery(int id, Stationery stationery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stationery.Id)
            {
                return BadRequest();
            }

            db.Entry(stationery).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationeryExists(id))
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

        // POST: api/Stationery
        [ResponseType(typeof(Stationery))]
        public IHttpActionResult PostStationery(Stationery stationery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StationerySet.Add(stationery);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stationery.Id }, stationery);
        }

        // DELETE: api/Stationery/5
        [ResponseType(typeof(Stationery))]
        public IHttpActionResult DeleteStationery(int id)
        {
            Stationery stationery = db.StationerySet.Find(id);
            if (stationery == null)
            {
                return NotFound();
            }

            db.StationerySet.Remove(stationery);
            db.SaveChanges();

            return Ok(stationery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StationeryExists(int id)
        {
            return db.StationerySet.Count(e => e.Id == id) > 0;
        }
    }
}