using GerenciamentoAPI.Models;
using GerenciamentoAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FornecedoresController : ControllerBase
{
    private readonly IRepository<Fornecedor> _repository;

    public FornecedoresController(IRepository<Fornecedor> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var fornecedor = await _repository.GetByIdAsync(id);
        return fornecedor == null ? NotFound() : Ok(fornecedor);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Fornecedor fornecedor)
    {
        await _repository.AddAsync(fornecedor);
        return CreatedAtAction(nameof(Get), new { id = fornecedor.Id }, fornecedor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Fornecedor fornecedor)
    {
        if (id != fornecedor.Id) return BadRequest();
        await _repository.UpdateAsync(fornecedor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
