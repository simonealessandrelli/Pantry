

using log4net;
using Pantry.Models;
using Pantry.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pantry.Controllers {
    public class FoodsController : ApiController {

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly IRepository<Food> EntityRepository = new EntityRepository<Food>();

        // GET: api/Foods
        public IEnumerable<Food> Get() {
            Log.Debug("GET Request => Food");
            return EntityRepository.Get();
        }

        // GET: api/Foods/{id}
        public Food Get(int id) {
            Log.Debug("GET Request => Food");
            var food = EntityRepository.GetById(id);
            if (food == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return food;
        }

        // POST: api/Foods
        public HttpResponseMessage Post([FromBody]Food food) {
            Log.Debug("POST Request => Food");
            food = EntityRepository.Add(food);
            var response = Request.CreateResponse(HttpStatusCode.Created, food);
            var uri = Url.Link("DefaultApi", new { id = food.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // PUT: api/Foods/{id}
        public void Put(int id, [FromBody]Food food) {
            Log.Debug("PUT Request => Food");
            food.Id = id;
            if (EntityRepository.Update(food) == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // DELETE: api/Foods/{id}
        public void Delete(int id) {
            Log.Debug("DELETE Request => Food");
            var food = EntityRepository.GetById(id);
            if (food == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            EntityRepository.Remove(food);
        }
    }
}