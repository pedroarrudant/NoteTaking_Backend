using MediatR;

namespace Application.Features.GetNoteById.Models
{
    public class GetNoteByIdInput : IRequest<GetNoteByIdOutput>
    {
        public int Id { get; set; }
    }
}
