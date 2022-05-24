using Application.RequestModels.CommandRequestModel.Mail;
using Application.Settings.Mail;
using Infrastructure.ExceptionHandler;
using MailKit.Net.Smtp;
using MailKit.Security;
using MediatR;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Infrastructure.Shared.CommandsHandler.Mail;

public class EmailCommandHandler : IRequestHandler<EmailRequestModel, string>
{
    private MailSettings _mailSettings { get; }
    public EmailCommandHandler(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }
    public async Task<string> Handle(EmailRequestModel request, CancellationToken cancellationToken)
    {
        try
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(request.From ?? _mailSettings.EmailFrom);
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = request.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.None);//SecureSocketOptions.Auto
            smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

        }
        catch (ThrowException)
        {
            throw new ThrowException();
        }
        return "Success";
    }
}
