namespace LW4_MIA_2.DTO
{
    public class TodoDto
    {
        public string? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
        public string? Day { get; set; } // Enum as string
    }
}
