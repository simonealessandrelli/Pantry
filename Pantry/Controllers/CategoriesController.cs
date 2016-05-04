using log4net;
using Pantry.Models;
using Pantry.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pantry.Controllers {
    public class CategoriesController : ApiController {

        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly IRepository<Category> EntityRepository = new EntityRepository<Category>();

        // GET: api/Categories
        public IEnumerable<Category> Get() {
            Log.Debug("GET Request => Category");
            return EntityRepository.Get();
        }

        // GET: api/Categories/{id}
        public Category Get(int id) {
            Log.Debug("GET Request => Category");
            var category = EntityRepository.GetById(id);
            if (category == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return category;
        }

        // POST: api/Categories
        public HttpResponseMessage Post([FromBody]Category category) {
            Log.Debug("POST Request => Category");
            category = EntityRepository.Add(category);
            var response = Request.CreateResponse(HttpStatusCode.Created, category);
            var uri = Url.Link("DefaultApi", new { id = category.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // PUT: api/Categories/{id}
        public void Put(int id, [FromBody]Category category) {
            Log.Debug("PUT Request => Category");
            category.Id = id;
            if (EntityRepository.Update(category) == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // DELETE: api/Categories/{id}
        public void Delete(int id) {
            Log.Debug("DELETE Request => Category");
            var category = EntityRepository.GetById(id);
            if (category == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            EntityRepository.Remove(category);
        }
    }
}
