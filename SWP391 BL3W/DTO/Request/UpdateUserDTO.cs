namespace SWP391_BL3W.DTO.Request
{
    public class UpdateUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public bool Status { get; set; } = false;
    }
}
