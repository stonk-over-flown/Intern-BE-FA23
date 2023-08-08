using System.ComponentModel.DataAnnotations;

namespace Test.Entity
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid().ToString("N");
            CreateTimes = DateTime.Now;
            LastUpdateTimes = DateTime.Now;
        }
        [Key]
        public string Id { get; set; }
        public DateTime CreateTimes { get; set; }
        public DateTime LastUpdateTimes { get; set; }
        public DateTime CreateUser { get; set; }
        public DateTime LastUpdateUser { get; set; }
    }
}
