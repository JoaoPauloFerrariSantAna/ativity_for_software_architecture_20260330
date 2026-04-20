using Microsoft.AspNetCore.Mvc;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Dtos.Requests;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;
using WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

namespace WorkFromSchool_20260408.BillingContext.Api.Controllers;

[ApiController()]
[Route("/[controller]")]
public class BoletoController : ControllerBase
{
    private readonly IBaseRepository<Boleto> _carteiraRepository;
    IContaBancariaRepositiory _contaBancariaRepositiory;

    public BoletoController(IBaseRepository<Boleto> carteiraRepository, IContaBancariaRepositiory contaBancariaRepositiory)
    {
        _carteiraRepository = carteiraRepository;
        _contaBancariaRepositiory = contaBancariaRepositiory;
    }

    [HttpGet("getAll")]
    public IActionResult GetAll()
    {
        return Ok(_carteiraRepository.All());
    }

    [HttpPost("postCarteira")]
    public IActionResult Post([FromBody] BoletoPostRequest carteiraRequest)
    {
        try
        {
            if (!_contaBancariaRepositiory.IsInDatabase(carteiraRequest.IdContaBancaria))
                throw new Exception("Conta Bancaria does not exists");

            _carteiraRepository.Post(
                new Boleto(
                    "abc",
                    new SaldoObject(carteiraRequest.Saldo).Saldo,
                    new ContaBancariaObject(carteiraRequest.IdContaBancaria).Get()
                )
            );
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    [HttpPatch("update")]
    public IActionResult Update([FromBody] Boleto carteira)
    {
        _carteiraRepository.Update(carteira);
        return Ok();
    }

    [HttpDelete("deleteById:id")]
    public IActionResult Delete(Guid id)
    {
        try { _carteiraRepository.Delete(id); }
        catch (Exception e) { return BadRequest(e.Message); }

        return Ok();
    }
}