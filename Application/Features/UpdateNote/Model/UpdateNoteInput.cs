using Application.Shared.Models;
using MediatR;

namespace Application.Features.UpdateNote.Model
{
    public class UpdateNoteInput : IRequest<UpdateNoteOutput>
    {
        public NoteModel Note { get; set; }
    }
}
