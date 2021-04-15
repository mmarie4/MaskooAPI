using DAL.Entities;
using DAL.Entities.Notes;
using DAL.Repositories.Notes;
using Services.Notes.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Notes
{
    public class NoteService : INoteService
    {

        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<ICollection<Note>> GetAllUserNotesAsync(Guid userId, string searchTerm)
        {
            var notes = await _noteRepository.GetAllByUserId(userId, searchTerm);

            return notes;
        }

        public async Task<Note> GetNoteAsync(Guid userId, Guid noteId)
        {
            var note = await _noteRepository.GetByIdAsync(noteId);

            return note;
        }

        public async Task<Note> CreateNoteAsync(Guid userId, NoteParameter noteParameter)
        {
            var note = new Note();

            note.Title = noteParameter.Title;
            note.Content = noteParameter.Content;
            note.UserId = userId;
            note.Stamp(userId);

            var result = await _noteRepository.AddAsync(note);

            await _noteRepository.SaveAsync();

            return result;
        }

        public async Task<Note> UpdateNoteAsync(Guid userId, Guid noteId, NoteParameter noteParameter)
        {
            var note = await _noteRepository.GetByIdAsync(noteId);

            note.Title = noteParameter.Title;
            note.Content = noteParameter.Content;
            note.Stamp(userId, false);

            var result = await _noteRepository.Update(note);

            await _noteRepository.SaveAsync();

            return result;
        }

        public async Task<Note> DeleteNoteAsync(Guid userId, Guid noteId)
        {
            var note = await _noteRepository.GetByIdAsync(noteId);

            var result = await _noteRepository.Remove(note);

            await _noteRepository.SaveAsync();

            return result;
        }
    }
}
