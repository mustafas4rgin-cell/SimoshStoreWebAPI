namespace SimoshStore;

public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } =new DateTime(2025, 2, 23);
    }