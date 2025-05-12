using Application.Features.InsertNote.Models;
using Application.Shared.Models;
using Application.Shared.Repositories.Interfaces;
using MediatR;

namespace Application.Features.InsertNote.UseCase
{
    public class InsertNoteUseCaseHandler : IRequestHandler<InsertNoteInput, InsertNoteOutput>
    {
        private readonly IBaseRepository<NoteModel> _repository;

        public InsertNoteUseCaseHandler(IBaseRepository<NoteModel> repository)
        {
            _repository = repository;
        }

        public async Task<InsertNoteOutput> Handle(InsertNoteInput request, CancellationToken cancellationToken)
        {
            var newId = await _repository.InsertAsync("notes", request.ToDomain());

            var result = request.ToDomain();
            result.Id = newId;

            return new InsertNoteOutput() { Note = result };
        }
    }
}
