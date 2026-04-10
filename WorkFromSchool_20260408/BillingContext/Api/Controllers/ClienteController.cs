using Microsoft.AspNetCore.Mvc;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;
using WorkFromSchool_20260408.BillingContext.Application.Domain.UseCases;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Enums;
using WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;

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

    [HttpGet("/getAll")]
    public IActionResult GetAll()
    {
        return Ok(_clienteRepository.All());
    }

    [HttpGet("getById:id")]
    public IActionResult GetById(int id)
    {
        try
        {
            return Ok(_clienteRepository.GetCliente(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost("postCliente")]
    public IActionResult PostCliente(string name, decimal amount)
    {
        try
        {
            Cliente cliente = new Cliente((new NameObject(name)).Name, (new AmountObject(amount)).Amount);
            _clienteRepository.Post(cliente);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Created();
    }

    [HttpPost("makeDeposit")]
    public IActionResult Deposit(MetodoPagamento metodo, decimal amount, int id)
    {
        try
        {
            new MetodoPagamentoObject(metodo);
            MakeDepositCase mdc = new MakeDepositCase(_clienteRepository);
            mdc.Deposit(id, (new AmountObject(amount)).Amount);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }

    [HttpPatch("update")]
    public IActionResult Update([FromBody] Cliente cliente)
    {
        _clienteRepository.Update(cliente);
        return Ok();
    }

    [HttpDelete("deleteById:id")]
    public IActionResult DeleteById(int id)
    {
        try
        {
            _clienteRepository.Delete(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }
}