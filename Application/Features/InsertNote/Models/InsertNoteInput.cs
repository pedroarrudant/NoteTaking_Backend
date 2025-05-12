using Application.Shared.Models;
using MediatR;

namespace Application.Features.InsertNote.Models
{
    public class InsertNoteInput : IRequest<InsertNoteOutput>
    {
        public NewNoteModel Note { get; set; }

        public NoteModel ToDomain()
        {
            var result = new NoteModel();

            result.Descricao = this.Note.Descricao;
            result.Titulo = this.Note.Titulo;
            result.Prioridade = this.Note.Prioridade;
            result.DataCriacao = this.Note.DataCriacao;
            result.Concluida = this.Note.Concluida;

            return result;
        }
    }
}

public class NewNoteModel
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Prioridade { get; set; }
    public DateTime DataCriacao { get; set; }
    public bool Concluida { get; set; }
}