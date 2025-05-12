using System.Net;
using Application.Features.DeleteNotes.Models;
using Application.Features.GetNoteById.Models;
using Application.Features.GetNoteList.Models;
using Application.Features.InsertNote.Models;
using Application.Features.UpdateNote.Model;
using Application.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DefaultAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NoteTakingController : ControllerBase
{
    private readonly ILogger<NoteTakingController> _logger;
    private readonly IMediator _mediator;

    public NoteTakingController(IMediator mediator, ILogger<NoteTakingController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Cria uma nova anotação
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> InsertNote([FromBody] NewNoteModel note, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new InsertNoteInput { Note = note }, cancellationToken);
        return CreatedAtAction(nameof(GetNote), new { id = result }, result);
    }

    /// <summary>
    /// Retorna a lista de anotações
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<NoteModel>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetNotes(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetNoteListInput(), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Retorna uma anotação específica por ID
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(NoteModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetNote([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetNoteByIdInput { Id = id }, cancellationToken);
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    /// <summary>
    /// Remove uma anotação
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteNote([FromRoute] int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteNotesInput { Id = id }, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Atualiza uma anotação
    /// </summary>
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> UpdateNote([FromBody] NoteModel note, CancellationToken cancellationToken)
    {
        await _mediator.Send(new UpdateNoteInput { Note = note }, cancellationToken);
        return NoContent();
    }
}
