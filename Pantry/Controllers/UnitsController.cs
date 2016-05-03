using Pantry.Models;
using Pantry.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pantry.Controllers {
    public class UnitsController : ApiController{

        static readonly IRepository<Units> EntityRepository = new EntityRepository<Units>();

        // GET: api/Units
        public IEnumerable<Units> Get(){
            return EntityRepository.Get();
        }

        // GET: api/Units/{id}
        public Units Get(int id) {
            var unit = EntityRepository.GetById(id);

            if (unit == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return unit;
        }

        // POST: api/Units
        public HttpResponseMessage Post([FromBody]Units unit) {
            unit = EntityRepository.Add(unit);

            var response = Request.CreateResponse(HttpStatusCode.Created, unit);

            var uri = Url.Link("DefaultApi", new { id = unit.Id });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        // PUT: api/Units/{id}
        public void Put(int id, [FromBody]Units unit) {
            unit.Id = id;

            if (EntityRepository.Update(unit) == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // DELETE: api/Unit/5
        public void Delete(int id) {
            var unit = EntityRepository.GetById(id);

            if (unit == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            EntityRepository.Remove(unit);
        }
    }
}
