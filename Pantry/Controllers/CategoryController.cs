namespace Pantry.Controllers {
    //public class CategoryController : ApiController{

    //    static readonly IEntityRepository<Category> Repository = new EntityRepository<Category>();

    //    // GET: api/Category
    //    public IEnumerable<Category> Get() {
    //        return Repository.GetAll();
    //    }

    //    // GET: api/Category/{id}
    //    public Category Get(int id){
    //        var category = Repository.Get(id);

    //        if (category == null)
    //            throw new HttpResponseException(HttpStatusCode.NotFound);

    //        return category;
    //    }


    //    // POST: api/Category
    //    public HttpResponseMessage Post([FromBody]Category category) {
    //        category = Repository.Add(category);

    //        var response = Request.CreateResponse(HttpStatusCode.Created, category);

    //        var uri = Url.Link("DefaultApi", new { id = category.Id });
    //        response.Headers.Location = new Uri(uri);

    //        return response;
    //    }

    //    // PUT: api/Category/{id}
    //    public void Put(int id, [FromBody]Category category) {
    //        category.Id = id;

    //        if (!Repository.Update(category))
    //            throw new HttpResponseException(HttpStatusCode.NotFound);

    //    }

    //    // DELETE: api/Category/{id}
    //    public void Delete(int id){
    //        var category = Repository.Get(id);

    //        if (category == null)
    //            throw new HttpResponseException(HttpStatusCode.NotFound);
    //        Repository.Delete(id);
    //    }
    //}
}
