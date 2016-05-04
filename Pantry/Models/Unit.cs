namespace Pantry.Models {
    public class Unit : IEntity {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}