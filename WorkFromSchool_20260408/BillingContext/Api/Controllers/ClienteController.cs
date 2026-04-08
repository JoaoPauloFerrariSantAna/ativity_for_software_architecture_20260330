using Microsoft.AspNetCore.Mvc;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;
using WorkFromSchool_20260408.BillingContext.Application.Domain.UseCases;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Enums;
using WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

namespace WorkFromSchool_20260408.BillingContext.Api.Controllers;

[ApiController()]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    [HttpPost("makeDeposit")]
    public IActionResult Deposit(MetodoPagamento metodo, decimal amount, int id)
    {
        try
        {
            new MetodoPagamentoObject(metodo);
            MakeDepositCase mdc = new MakeDepositCase(_clienteRepository);
            mdc.Deposit(id, new AmountObject(amount));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }
}