using Application.Features.UpdateNote.Model;
using Application.Shared.Models;
using Application.Shared.Repositories.Interfaces;
using MediatR;

namespace Application.Features.UpdateNote.UseCase
{
    internal class UpdateNoteUseCaseHandler : IRequestHandler<UpdateNoteInput, UpdateNoteOutput>
    {
        private readonly IBaseRepository<NoteModel> _repository;

        public UpdateNoteUseCaseHandler(IBaseRepository<NoteModel> repository)
        {
            _repository = repository;
        }

        public async Task<UpdateNoteOutput> Handle(UpdateNoteInput request, CancellationToken cancellationToken)
        {
            var result = await _repository.UpdateAsync("notes", request.Note);

            return new UpdateNoteOutput() { Note = result };
        }
    }
}
