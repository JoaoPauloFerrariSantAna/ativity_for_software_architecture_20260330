using Billing.Domain.Entities;
using Jwt.Interfaces;
using Jwt.ValueObjects;

namespace Jwt.UseCases
{
    public class MakeDepositCase
    {
        public void Deposit(IClienteRepository repository, int id, AmountObject amount)
        {
            Cliente cliente = repository.GetCliente(id);
            cliente.Deposit(amount.Amount);
            repository.Update(cliente);
        }
    }
}