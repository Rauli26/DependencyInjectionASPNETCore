namespace DependencyInjectionASPNETCore.Services
{
    public interface IEmailSenderService
    {
        string SendEmail(string email);
    }
    public class EmailSenderService : IEmailSenderService
    {
        public string SendEmail(string email)
        {
           return email;
        }
    }
}
