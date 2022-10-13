namespace Domain.Entities.Models.DTO
{
    public class TodosDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool IsClosed { get; set; }
    }
}
