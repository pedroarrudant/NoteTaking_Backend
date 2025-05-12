using System.Text.Json.Serialization;

namespace Application.Shared.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Prioridade { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Concluida { get; set; }
    }
}
