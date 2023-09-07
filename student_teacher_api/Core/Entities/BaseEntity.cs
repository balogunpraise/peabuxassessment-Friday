namespace Core.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; } = new Guid().ToString();
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
