using DAL.Entities.Notes;
using Services.Notes.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Notes
{
    public interface INoteService
    {
        Task<ICollection<Note>> GetAllUserNotesAsync(Guid userId, string searchTerm);
        Task<Note> GetNoteAsync(Guid userId, Guid noteId);
        Task<Note> CreateNoteAsync(Guid userId, NoteParameter noteParameter);
        Task<Note> UpdateNoteAsync(Guid userId, Guid noteId, NoteParameter noteParameter);
        Task<Note> DeleteNoteAsync(Guid userId, Guid noteId);
    }
}
