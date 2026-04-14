using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;

namespace WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

public class CarteiraObject
{
    private readonly IClienteRepository _clienteRepository;

    public Carteira Carteira { get; set; }

    public CarteiraObject(IClienteRepository clienteRepository, Guid carteiraId)
    {
        _clienteRepository = clienteRepository;

        if (!_clienteRepository.HasCarteira(carteiraId)) throw new Exception("Carteira does exists");

        this.Carteira = _clienteRepository.GetCarteira(carteiraId);
    }
}