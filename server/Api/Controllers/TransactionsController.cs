using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using server.Application.Transactions.Queries.GetAllTransactions;
// using server.Application.Transactions.Commands;

namespace server.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<GetAllTransactionsDto> GetAll(
        [FromQuery] GetAllTransactionsQuery request, 
        CancellationToken cancellationToken
    )
    {
        return await _mediator.Send(request, cancellationToken);
    }

    // [HttpGet("{id:guid}")]
    // public async Task<ActionResult<TransactionDto>> GetById(
    //     Guid id,
    //     CancellationToken cancellationToken
    // )
    // {
    //     var query = new GetTransactionByIdQuery(id);
    //     var result = await _mediator.Send(query, cancellationToken);
        
    //     if (result == null)
    //         return NotFound();
            
    //     return Ok(result);
    // }

    // [HttpPost]
    // public async Task<ActionResult<TransactionDto>> Create(
    //     [FromBody] CreateTransactionCommand request, 
    //     CancellationToken cancellationToken
    // )
    // {
    //     var result = await _mediator.Send(request, cancellationToken);
    //     return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    // }

    // [HttpPut("{id:guid}")]
    // public async Task<ActionResult<TransactionDto>> Update(
    //     Guid id,
    //     [FromBody] UpdateTransactionCommand request,
    //     CancellationToken cancellationToken
    // )
    // {
    //     if (id != request.Id)
    //         return BadRequest("ID mismatch");
            
    //     var result = await _mediator.Send(request, cancellationToken);
        
    //     if (result == null)
    //         return NotFound();
            
    //     return Ok(result);
    // }

    // [HttpDelete("{id:guid}")]
    // public async Task<IActionResult> Delete(
    //     Guid id,
    //     CancellationToken cancellationToken
    // )
    // {
    //     var command = new DeleteTransactionCommand(id);
    //     var result = await _mediator.Send(command, cancellationToken);
        
    //     if (!result)
    //         return NotFound();
            
    //     return NoContent();
    // }
}
