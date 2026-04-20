using System.Net.Mail;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;

namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

public class ContaBancariaObject
{
    private readonly IContaBancariaRepositiory _contaBancariaRepository;
    public Guid IdContaBancaria;

    public ContaBancariaObject(Guid idContaBancaria)
    {
        if(!_contaBancariaRepository.IsInDatabase(idContaBancaria)) throw new Exception("Unknown conta bancaria");

        IdContaBancaria = idContaBancaria;
    }

    public ContaBancaria Get() { return _contaBancariaRepository.Get(IdContaBancaria); }
}