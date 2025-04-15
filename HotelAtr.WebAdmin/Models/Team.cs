namespace HotelAtr.WebAdmin.Models
{
	public class Team
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public string CreatedBy { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
        public string Description { get; set; }
        public int PositionId { get; set; }

        public Position Position { get; set; }
    }

	public class TeamLynkType
	{
		public int Id { get; set; }
        public int LynkTypeId { get; set; }
        public int TeamId { get; set; }

        public ICollection<Team> Teams { get; set; }
        public ICollection<LynkType> LynkTypes { get; set; }
    }
}
