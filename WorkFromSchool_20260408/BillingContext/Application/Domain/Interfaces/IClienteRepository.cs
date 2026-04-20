using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;

namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;
public interface IClienteRepository : IBaseRepository<Cliente>
{
    public Carteira GetCarteira(Guid carteiraId);
    public bool IsCpfUnique(string cpf);
    public bool HasCarteira(Guid carteiraId);
}