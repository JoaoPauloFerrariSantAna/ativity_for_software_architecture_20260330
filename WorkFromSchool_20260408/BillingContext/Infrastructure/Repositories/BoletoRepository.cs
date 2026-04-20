using System.Runtime.CompilerServices;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;

namespace WorkFromSchool_20260408.BillingContext.Infrastructure.Repositories;

public class BoletoRepository : IBaseRepository<Boleto>
{
    private static List<Boleto> _boletos = new List<Boleto>();

    public List<Boleto> All() { return _boletos; }

    public void Delete(Guid id)
    {
        if (!IsInDatabase(id))
            throw new Exception("Cliente does not exists");
        
        _boletos.Remove(Get(id));
    }

    public Boleto Get(Guid id) { return _boletos.Find(b => id == b.Id); }

    public bool IsInDatabase(Guid id) { return (_boletos.Find(b => id == b.Id) != null); }

    public void Post(Boleto boleto)
    {
        if (boleto == null)
            throw new Exception("Boleto data is empty");
        
        if (IsInDatabase(boleto.Id))
            throw new Exception("Boleto is in database already");
        
        _boletos.Add(boleto);
    }

    public void Update(Boleto boleto)
    {
        Boleto b = null;

        if (boleto == null)
            throw new Exception("Client data is empty");
        
        if (!IsInDatabase(boleto.Id))
            throw new Exception("Cliente does not exists");
        
        b = Get(boleto.Id);
        b = boleto;
    }
}