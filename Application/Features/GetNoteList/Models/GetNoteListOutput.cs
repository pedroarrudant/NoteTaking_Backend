using Application.Shared.Models;

namespace Application.Features.GetNoteList.Models
{
    public class GetNoteListOutput
    {
        public List<NoteModel> Notes { get; set; }
    }
}
