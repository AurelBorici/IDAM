using MediatR;

namespace Application.RequestModels.CommandRequestModel.Mail;

public class EmailRequestModel : IRequest<string>
{
    public string? To { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
    public string? From { get; set; }
}
