namespace PolicyManagementAPI.Model
{
    public class MailRequest
    {
        public string ToEmailId { get; set; }
       
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
    }
}
