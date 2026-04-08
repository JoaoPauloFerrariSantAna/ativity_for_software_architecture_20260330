using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;

namespace WorkFromSchool_20260408.BillingContext.Application.Domain.UseCases;

public class MakeDepositCase
{
    private readonly IClienteRepository _clienteRepository;

    public MakeDepositCase(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public void Deposit(int id, AmountObject amount)
    {
        Cliente cliente = _clienteRepository.GetCliente(id);
        cliente.Deposit(amount.Amount);
        _clienteRepository.Update(cliente);
    }
}