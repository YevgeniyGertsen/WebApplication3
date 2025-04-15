namespace HotelAtr.WebApi.Model
{
    public class Team
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; } = "admin";

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; } = null;
        public string Description { get; set; }
        public byte[]? ImageTeam { get; set; } = null;
        public int PositionId { get; set; }

        public Position? Position { get; set; } = null;
    }
}
