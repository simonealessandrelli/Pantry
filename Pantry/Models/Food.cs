namespace Pantry.Models {
    public class Food : IEntity {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Category Category {get;set;}
        public virtual Unit Unit { get; set; }
        public virtual decimal Quantity { get; set; }
    }

}