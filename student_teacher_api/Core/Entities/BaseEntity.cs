namespace Core.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; } = new Guid().ToString();
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTimeOffset.Now;
        }
    }
}
