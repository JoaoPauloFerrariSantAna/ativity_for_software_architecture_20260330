using Microsoft.AspNetCore.Mvc;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Dtos.Requests;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;
using WorkFromSchool_20260408.BillingContext.Application.Domain.ValueObjects;

namespace WorkFromSchool_20260408.BillingContext.Api.Controllers;

[ApiController()]
[Route("/[controller]")]
public class PixController : ControllerBase
{
    // we are using ICarteiraRepository and not an other entity because this entity (carteira)
    // is the father of: pix, boleto and cartao
    // so the same methods that are in the interface must work also to its children
    private readonly IBaseRepository<Pix> _carteiraRepository;
    private readonly IContaBancariaRepositiory _contaBancariaRepository;

    public PixController(IBaseRepository<Pix> carteiraRepository, IContaBancariaRepositiory contaBancariaRepositiory)
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
    public IActionResult Post([FromBody] PixPostRequest carteiraRequest)
    {
        try
        {
            _carteiraRepository.Post(
                new Pix(
                    (new ChavePixObject("abc")).ChavePix,
                    (new SaldoObject(carteiraRequest.Saldo)).Saldo,
                    (new ContaBancariaObject(carteiraRequest.IdContaBancaria)).Get()
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
    public IActionResult Update([FromBody] Pix carteira)
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