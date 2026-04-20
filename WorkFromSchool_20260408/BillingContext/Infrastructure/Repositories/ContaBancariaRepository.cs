using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;

namespace WorkFromSchool_20260408.BillingContext.Infrastructure.Repositories;

public class ContaBancariaRepository : IContaBancariaRepositiory
{
    private static List<ContaBancaria> _contaBancariaList = new List<ContaBancaria>();

    public List<ContaBancaria> All() { return _contaBancariaList; }

    public bool IsInDatabase(Guid id) { return (_contaBancariaList.Find(cb => id == cb.Id) != null); }

    public ContaBancaria Get(Guid id) { return _contaBancariaList.Find(cb => id == cb.Id); }

    public void Delete(Guid id)
    {
        if (!IsInDatabase(id))
            throw new Exception("Conta bancária does not exists");
        
        _contaBancariaList.Remove(Get(id));
    }

    public void Post(ContaBancaria contaBancaria)
    {
        if (contaBancaria == null)
            throw new Exception("Conta bancária must be filled");
        
        if(IsInDatabase(contaBancaria.Id))
            throw new Exception("Conta bancária already exists");
        
        _contaBancariaList.Add(contaBancaria);
    }

    public void Update(ContaBancaria contaBancaria)
    {
        ContaBancaria cb = null;
        
        if (contaBancaria == null)
            throw new Exception("Conta bancária must be filled");
        
        if (!IsInDatabase(contaBancaria.Id))
            throw new Exception("Conta bancária does not exists");
        
        cb = Get(contaBancaria.Id);
        cb = contaBancaria;
    }
}