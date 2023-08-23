using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolicyManagementAPI.Model;
using PolicyManagementAPI.Service;

namespace PolicyManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSendController : ControllerBase
    {
        private readonly IEmailService emailService;

        public EmailSendController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost("SendEmail")]

        public async Task<IActionResult> SendEmail([FromForm]MailRequest request)
        {
            try
            {
                //MailRequest request = new MailRequest();
/*                request.ToEmailId = "mohitverma.540.mv@gmail.com";
                request.EmailSubject = " Policy Registered Successfully";
                request.EmailBody = "Hi Admin, Policy added";*/
                await emailService.SendEmailAsync(request);
                return Ok();
            }
           catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
