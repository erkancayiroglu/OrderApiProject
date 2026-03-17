using HotelProject.DataAccessLayer.Repositories;
using MimeKit;
using MailKit.Net.Smtp;
using OrderProject.DataAccessLayer.Abstract;
using OrderProject.DataAccessLayer.Concrete;
using OrderProject.DtoLayer.Mail;
using OrderProject.EntityLayer.Concrete;



namespace OrderProject.DataAccessLayer.EntityFramework
{
    public class EfSendEmailDal : GenericRepository<SendEmail>, ISendEmailDal
    {
        public EfSendEmailDal(Context context) : base(context)
        {
        }

        public void AddSendEmail(AddSendEmailDto sendEmail)
        {
            var mimeMessage = new MimeMessage();

            mimeMessage.From.Add(new MailboxAddress(
                sendEmail.SenderName,
                sendEmail.SenderMail));

            mimeMessage.To.Add(new MailboxAddress(
                sendEmail.ReceiverName,
                sendEmail.ReceiverMail));

            mimeMessage.Subject = sendEmail.Title;

            mimeMessage.Body = new TextPart("plain")
            { 
                Text = sendEmail.Content
            };

            SmtpClient  client = new SmtpClient();

            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate(
                "erkancayiroglu02@gmail.com",
                "fjaxcnmuqzxfeuhp"
            );

            client.Send(mimeMessage);
            client.Disconnect(true);
        }

        public void PasswordSendEmail(AddSendEmailDto sendEmail)
        {
            var mimeMessage = new MimeMessage();

            mimeMessage.From.Add(new MailboxAddress(
                sendEmail.SenderName,
                sendEmail.SenderMail));

            mimeMessage.To.Add(new MailboxAddress(
                sendEmail.ReceiverName,
                sendEmail.ReceiverMail));

            mimeMessage.Subject = sendEmail.Title;

            mimeMessage.Body = new TextPart("html")
            {
                Text = sendEmail.Content
            };

            SmtpClient client = new SmtpClient();

            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate(
                "erkancayiroglu02@gmail.com",
                "fjaxcnmuqzxfeuhp"
            );

            client.Send(mimeMessage);
            client.Disconnect(true);
        }
    }
}
