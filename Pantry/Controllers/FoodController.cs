

namespace Pantry.Controllers {
    //public class FoodController : ApiController{

    //    static readonly IEntityRepository<Food> Repository = new EntityRepository<Food>();

    //    // GET: api/Food
    //    public IEnumerable<Food> Get() {
    //        return Repository.GetAll();
    //    }

    //    // GET: api/Food/{id}
    //    public Food Get(int id) {
    //        var food = Repository.Get(id);

    //        if (food == null)
    //            throw new HttpResponseException(HttpStatusCode.NotFound);

    //        return food;
    //    }


    //    // POST: api/Food
    //    public HttpResponseMessage Post([FromBody]Food food) {
    //        food = Repository.Add(food);

    //        var response = Request.CreateResponse(HttpStatusCode.Created, food);

    //        var uri = Url.Link("DefaultApi", new { id = food.Id });
    //        response.Headers.Location = new Uri(uri);

    //        return response;
    //    }

    //    // PUT: api/Food/{id}
    //    public void Put(int id, [FromBody]Food food) {
    //        food.Id = id;

    //        if (!Repository.Update(food))
    //            throw new HttpResponseException(HttpStatusCode.NotFound);

    //    }

    //    // DELETE: api/Food/{id}
    //    public void Delete(int id) {
    //        var food = Repository.Get(id);

    //        if (food == null)
    //            throw new HttpResponseException(HttpStatusCode.NotFound);
    //        Repository.Delete(id);
    //    }
    //}
}
