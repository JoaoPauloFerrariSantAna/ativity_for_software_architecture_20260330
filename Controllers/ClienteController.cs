using ConsoleApp2.Enums;
using Jwt.Interfaces;
using Jwt.UseCases;
using Jwt.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Controllers;

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
            MakeDepositCase mdc = new MakeDepositCase();
            mdc.Deposit(_clienteRepository, id, new AmountObject(amount));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }
}