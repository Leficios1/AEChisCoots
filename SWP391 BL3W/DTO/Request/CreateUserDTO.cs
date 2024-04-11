namespace SWP391_BL3W.DTO.Request

{
    public class CreateUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string? phone { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public bool status { get; set; }
        public int RoleId { get; set; }
    }
}
