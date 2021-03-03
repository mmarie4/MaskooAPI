using AutoMapper;
using DAL.Entities.Notes;
using MaskooAPI.Models.Notes;
using Services.Notes.Models;

namespace MaskooAPI.Mappers
{
    public class NoteMapper : Profile
    {
        public NoteMapper()
        {
            CreateMap<Note, NoteResponse>();

            CreateMap<NoteRequest, NoteParameter>();
        }
    }
}
