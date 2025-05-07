using Application.Shared.Models;
using MediatR;

namespace Application.Features.InsertNote.Models
{
    public class InsertNoteInput : IRequest<InsertNoteOutput>
    {
        public NoteModel Note { get; set; }
    }
}
