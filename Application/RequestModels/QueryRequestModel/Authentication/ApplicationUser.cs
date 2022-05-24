namespace Application.RequestModels.QueryRequestModel.Authentication;

public class ApplicationUser
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public List<RefreshTokenModel>? RefreshTokens { get; set; }
    public bool OwnsToken(string token)
    {
        return this.RefreshTokens?.Find(x => x.Token == token) != null;
    }
}
