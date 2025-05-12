using Application.Features.GetNoteById.Models;
using Application.Shared.Models;
using Application.Shared.Repositories.Interfaces;
using MediatR;

namespace Application.Features.GetNoteById.UseCase
{
    public class GetNoteByidUseCaseHandler : IRequestHandler<GetNoteByIdInput, GetNoteByIdOutput>
    {
        private readonly IBaseRepository<NoteModel> _repository;
        public GetNoteByidUseCaseHandler(IBaseRepository<NoteModel> repository)
        {
            _repository = repository;
        }
        public async Task<GetNoteByIdOutput?> Handle(GetNoteByIdInput request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync("notes", request.Id);

            return new GetNoteByIdOutput().FromDomain(result);
        }
    }
}