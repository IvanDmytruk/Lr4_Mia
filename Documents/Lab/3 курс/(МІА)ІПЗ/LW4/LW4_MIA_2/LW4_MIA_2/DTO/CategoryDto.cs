namespace LW4_MIA_2.DTO
{
    public class CategoryDto
    {
        public string? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Type { get; set; }    // Enum as string
    }
}
