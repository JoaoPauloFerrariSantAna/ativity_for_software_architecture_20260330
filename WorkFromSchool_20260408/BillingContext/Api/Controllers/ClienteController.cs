using Microsoft.AspNetCore.Mvc;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;
using WorkFromSchool_20260408.BillingContext.Application.Domain.UseCases;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Enums;
using WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Dtos.Requests;

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

    [HttpGet("getAll")]
    public IActionResult GetAll()
    {
        return Ok(_clienteRepository.All());
    }

    [HttpGet("getById:id")]
    public IActionResult Get(Guid id)
    {
        try { return Ok(_clienteRepository.Get(id)); }
        catch (Exception e) { return NotFound(e.Message); }
    }

    [HttpPost("postCliente")]
    public IActionResult Post([FromBody] ClientePostRequest postRequest)
    {
        try
        {
            _clienteRepository.Post(
                    new Cliente(
                        (new NomeObject(postRequest.Name)).Nome,
                        (new SaldoObject(postRequest.Amount)).Saldo,
                        (new CpfObject(postRequest.Cpf)).Cpf,
                        (new EmailObject(postRequest.Email)).Email,
                        (new CarteiraObject(_clienteRepository, postRequest.CarteiraId).Carteira)
                    )
            );
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Created();
    }

    [HttpPost("makeDeposit")]
    public IActionResult Deposit(MetodoPagamento metodo, decimal amount, Guid id)
    {
        try
        {
            new MetodoPagamentoObject(metodo);
            MakeDepositCase mdc = new MakeDepositCase(_clienteRepository);
            mdc.Deposit(id, (new SaldoObject(amount)).Saldo);
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
    public IActionResult Delete(Guid id)
    {
        try { _clienteRepository.Delete(id); }
        catch (Exception e) { return BadRequest(e.Message); }

        return Ok();
    }
}