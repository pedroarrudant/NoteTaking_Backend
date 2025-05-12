using Application.Shared.Models;
using static MassTransit.ValidationResultExtensions;

namespace Application.Features.GetNoteById.Models
{
    public class GetNoteByIdOutput : NoteModel
    {
        public GetNoteByIdOutput FromDomain(NoteModel origin)
        {
            return new GetNoteByIdOutput()
            {
                Id = origin.Id,
                Titulo = origin.Titulo,
                Descricao = origin.Descricao,
                Prioridade = origin.Prioridade,
                DataCriacao = origin.DataCriacao,
                Concluida = origin.Concluida
            };
        }
    }
}
