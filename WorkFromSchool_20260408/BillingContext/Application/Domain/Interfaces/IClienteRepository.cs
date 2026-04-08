using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;

namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;

public interface IClienteRepository
{
    public Cliente GetCliente(int id);
    public void Update(Cliente cliente);
}
