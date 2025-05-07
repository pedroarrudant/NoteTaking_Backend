using System.Net;
using Application.Features.InsertNote.Models;
using Application.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DefaultAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteTakingController : Controller
    {
        private readonly ILogger<NoteTakingController> _logger;
        private readonly IMediator _mediator;

        public NoteTakingController(IMediator mediator, ILogger<NoteTakingController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task InsertNote([FromBody] NoteModel note, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new InsertNoteInput() { Note = note }, cancellationToken);
        }
    }
}
