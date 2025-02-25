namespace WebApplication3.Models
{
    public interface IMessage
    {
        public bool SendMessage(string to, string subject, string message);
    }
}
