namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;

using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Enums;

interface IBillingRepository
{
    public Cartao CardRegister(string numero, TipoCartao tipo, string cvv, DateOnly validade, string nomeTitular);
    public Cartao CardDelete(string numero);
    public ContaBancaria AccountRegister(string numero, string agencia, string banco);
    public ContaBancaria AccountDelete(string numero, string agencia, string banco);
    public Transacao Deposit(decimal valor, MetodoPagamento metodoPagamento);
    public Transacao Withdrawal(decimal valor, ContaBancaria contaBancaria);
}