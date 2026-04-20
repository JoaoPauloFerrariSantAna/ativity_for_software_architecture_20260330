namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Dtos.Requests;

public class ClientePostRequest
{
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public decimal Amount { get; set; }
    public Guid CarteiraId { get; set; }

    public ClientePostRequest(string name, string cpf, string email, decimal amount, Guid carteiraId)
    {
        this.Name = name;
        this.Cpf = cpf;
        this.Email = email;
        this.Amount = amount;
        this.CarteiraId = carteiraId;
    }
}
