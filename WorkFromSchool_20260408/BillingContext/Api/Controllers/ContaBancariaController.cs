using Billing.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Dtos.Requests;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;
using WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

namespace WorkFromSchool_20260408.BillingContext.Api.Controllers;

[ApiController()]
[Route("api/[controller]")]
public class ContaBancariaController : ControllerBase
{
    private readonly IContaBancariaRepositiory _contaBancariaRepository;
    
    public ContaBancariaController(IContaBancariaRepositiory contaBancariaRepositiory)
    {
        _contaBancariaRepository = contaBancariaRepositiory;
    }

    [HttpGet("getAll")]
    public IActionResult GetAll()
    {
        return Ok(_contaBancariaRepository.All());
    }

    [HttpGet("getById:id")]
    public IActionResult Get(Guid id)
    {
        try { return Ok(_contaBancariaRepository.Get(id)); }
        catch(Exception e) { return BadRequest(e.Message); }
    }

    [HttpPost("postContaBancaria")]
    public IActionResult Post([FromBody] ContaBancariaPostRequest contaBancaria)
    {
        try
        {
            _contaBancariaRepository.Post(
                new ContaBancaria(
                    (new NomeAgenciaObject(contaBancaria.Agencia)).Agencia,
                    (new NumeroCartao(contaBancaria.Numero)).Numero,
                    (new NomeBanco(contaBancaria.Banco)).Banco
                )
            );
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }
}