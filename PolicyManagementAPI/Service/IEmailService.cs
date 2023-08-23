using PolicyManagementAPI.Model;

namespace PolicyManagementAPI.Service
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
