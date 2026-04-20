using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;

namespace WorkFromSchool_20260408.BillingContext.Infrastructure.Repositories;

public class CartaoRepository : IBaseRepository<Cartao>
{
    private static List<Cartao> _cartoes = new List<Cartao>();

    public List<Cartao> All() { return _cartoes; }

    public void Delete(Guid id)
    {
        if (!IsInDatabase(id)) throw new Exception("Cliente does not exists");
        _cartoes.Remove(Get(id));
    }

    public Cartao Get(Guid id) { return _cartoes.Find(b => id == b.Id); }

    public bool IsInDatabase(Guid id) { return (_cartoes.Find(b => id == b.Id) != null); }

    public void Post(Cartao cartao)
    {
        if (cartao == null) throw new Exception("Boleto data is empty");
        if (IsInDatabase(cartao.Id)) throw new Exception("Boleto is in database already");
        _cartoes.Add(cartao);
    }

    public void Update(Cartao cartao)
    {
        Cartao ct = null;

        if (cartao == null) throw new Exception("Client data is empty");
        if (!IsInDatabase(cartao.Id)) throw new Exception("Cliente does not exists");
        ct = Get(cartao.Id);
        ct = cartao;
    }
}