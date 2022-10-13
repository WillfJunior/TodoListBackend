namespace Domain.Entities
{
    public class Todos: BaseEntity
    {
        public string? Description { get; set; }
        public bool IsClosed { get; set; }
    }
}
