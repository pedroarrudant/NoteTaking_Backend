using MediatR;

namespace Application.Features.DeleteNotes.Models
{
    public class DeleteNotesInput : IRequest<DeleteNotesOutput>
    {
        public int Id { get; set; }
    }
}
