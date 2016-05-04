using log4net;
using Pantry.Models;
using Pantry.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pantry.Controllers {
    public class UnitsController : ApiController{

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly IRepository<Unit> EntityRepository = new EntityRepository<Unit>();

        // GET: api/Units
        public IEnumerable<Unit> Get(){
            Log.Debug("GET Request => Units");
            return EntityRepository.Get();
        }

        // GET: api/Units/{id}
        public Unit Get(int id) {
            Log.Debug("GET Request => Unit");
            var unit = EntityRepository.GetById(id);
            if (unit == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return unit;
        }

        // POST: api/Units
        public HttpResponseMessage Post([FromBody]Unit unit) {
            Log.Debug("POST Request => Unit");
            unit = EntityRepository.Add(unit);
            var response = Request.CreateResponse(HttpStatusCode.Created, unit);
            var uri = Url.Link("DefaultApi", new { id = unit.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // PUT: api/Units/{id}
        public void Put(int id, [FromBody]Unit unit) {
            Log.Debug("PUT Request => Unit");
            unit.Id = id;
            if (EntityRepository.Update(unit) == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // DELETE: api/Units/{id}
        public void Delete(int id) {
            Log.Debug("DELETE Request => Unit");
            var unit = EntityRepository.GetById(id);
            if (unit == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            EntityRepository.Remove(unit);
        }
    }
}
