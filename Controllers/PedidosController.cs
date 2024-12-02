using GerenciamentoAPI.Models;
using GerenciamentoAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly IRepository<Pedido> _repository;

    public PedidosController(IRepository<Pedido> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var pedido = await _repository.GetByIdAsync(id);
        return pedido == null ? NotFound() : Ok(pedido);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Pedido pedido)
    {
        await _repository.AddAsync(pedido);
        return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Pedido pedido)
    {
        if (id != pedido.Id) return BadRequest();
        await _repository.UpdateAsync(pedido);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
