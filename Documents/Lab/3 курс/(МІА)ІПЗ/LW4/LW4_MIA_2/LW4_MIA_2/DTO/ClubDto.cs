namespace LW4_MIA_2.DTO
{
    public class ClubDto
    {
        public string? Id { get; set; }
        public string Departament { get; set; } = string.Empty;
        public string Adressa { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        public string Contacts { get; set; } = string.Empty;
        public double MountlyPayment { get; set; }
    }
}
