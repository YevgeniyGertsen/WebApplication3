namespace HotelAtr.WebAdmin.Models
{
	public class LynkType
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public string CreatedBy { get; set; }

		public string Name { get; set; }
        public string PathImage { get; set; }
        public string Url { get; set; }
    }
}