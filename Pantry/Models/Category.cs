namespace Pantry.Models {
    public class Category : IEntity {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

    }
}