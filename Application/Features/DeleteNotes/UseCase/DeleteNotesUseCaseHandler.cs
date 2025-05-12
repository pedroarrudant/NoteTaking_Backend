using Application.Features.DeleteNotes.Models;
using Application.Shared.Models;
using Application.Shared.Repositories.Interfaces;
using MediatR;

namespace Application.Features.DeleteNotes.UseCase
{
    public class DeleteNotesUseCaseHandler : IRequestHandler<DeleteNotesInput, DeleteNotesOutput>
    {
        private readonly IBaseRepository<NoteModel> _repository;

        public DeleteNotesUseCaseHandler(IBaseRepository<NoteModel> repository)
        {
            _repository = repository;
        }

        public async Task<DeleteNotesOutput> Handle(DeleteNotesInput request, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteAsync("notes", request.Id);

            return new DeleteNotesOutput();
        }
    }
}
