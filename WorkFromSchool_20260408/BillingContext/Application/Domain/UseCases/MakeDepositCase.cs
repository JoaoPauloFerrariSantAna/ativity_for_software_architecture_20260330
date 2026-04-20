using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;

namespace WorkFromSchool_20260408.BillingContext.Application.Domain.UseCases;

public class MakeDepositCase
{
    private readonly IClienteRepository _clienteRepository;

    public MakeDepositCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public void Deposit(Guid id, decimal amount)
    {
        Cliente cliente = _clienteRepository.Get(id);
        cliente.Deposit(amount);
        _clienteRepository.Update(cliente);
    }
}