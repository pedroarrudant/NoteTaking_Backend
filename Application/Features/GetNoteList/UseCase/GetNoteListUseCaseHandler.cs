using Application.Features.GetNoteList.Models;
using Application.Shared.Models;
using Application.Shared.Repositories.Interfaces;
using MediatR;

namespace Application.Features.GetNoteList.UseCase
{
    public class GetNoteListUseCaseHandler : IRequestHandler<GetNoteListInput, GetNoteListOutput>
    {
        private readonly IBaseRepository<NoteModel> _repository;
        public GetNoteListUseCaseHandler(IBaseRepository<NoteModel> repository)
        {
            _repository = repository;
        }
        public async Task<GetNoteListOutput> Handle(GetNoteListInput request, CancellationToken cancellationToken)
        {
            var notes = await _repository.GetAllAsync("notes");
            return new GetNoteListOutput
            {
                Notes = notes.ToList()
            };
        }
    }
}