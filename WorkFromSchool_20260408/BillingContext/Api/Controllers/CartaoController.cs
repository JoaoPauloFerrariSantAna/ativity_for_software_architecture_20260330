using Microsoft.AspNetCore.Mvc;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Dtos.Requests;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;
using WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;
using WorkFromSchool_20260408.BillingContext.Infrastructure.Repositories;

namespace WorkFromSchool_20260408.BillingContext.Api.Controllers;

[ApiController()]
[Route("/[controller]")]
public class CartaoController : ControllerBase
{
    private readonly IBaseRepository<Cartao> _carteiraRepository;
    private readonly IContaBancariaRepositiory _contaBancariaRepository;

    public CartaoController(IBaseRepository<Cartao> carteiraRepository, IContaBancariaRepositiory contaBancariaRepositiory)
    {
        _carteiraRepository = carteiraRepository;
        _contaBancariaRepository = contaBancariaRepositiory;
    }

    [HttpGet("getAll")]
    public IActionResult GetAll()
    {
        return Ok(_carteiraRepository.All());
    }

    [HttpPost("postCarteira")]
    public IActionResult Post([FromBody] CartaoPostRequest carteiraRequest)
    {
        try
        {
            if (!_contaBancariaRepository.IsInDatabase(carteiraRequest.IdContaBancaria))
                throw new Exception("Conta bancaria does not exists");

            _carteiraRepository.Post(
                new Cartao(
                    new NomeObject(carteiraRequest.Numero).Nome,
                    new CvvObject(carteiraRequest.CVV).Cvv,
                    new NomeObject(carteiraRequest.NomeTitular).Nome,
                    new SaldoObject(carteiraRequest.Saldo).Saldo,
                    carteiraRequest.Validade,
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
    public IActionResult Update([FromBody] Cartao carteira)
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
