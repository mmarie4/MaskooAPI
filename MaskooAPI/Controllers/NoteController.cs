﻿using AutoMapper;
using MaskooAPI.Models.Notes;
using MaskooAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Notes;
using Services.Notes.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaskooAPI.Controllers
{
    [Route("api/notes")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        private readonly IMapper _mapper;

        public NoteController(INoteService noteService, IMapper mapper)
        {
            _noteService = noteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ICollection<NoteResponse>> GetAllUserNote([FromQuery(Name = "search_term")] string searchTerm)
        {
            var userId = HttpContext.User.ExtractUserId();

            var note = await _noteService.GetAllUserNotesAsync(userId, searchTerm);

            return _mapper.Map<ICollection<NoteResponse>>(note);
        }

        [HttpGet("{noteId}")]
        public async Task<NoteResponse> GetNote(Guid noteId)
        {
            var userId = HttpContext.User.ExtractUserId();

            var note = await _noteService.GetNoteAsync(userId, noteId);

            return _mapper.Map<NoteResponse>(note);
        }

        [HttpPost]
        public async Task<NoteResponse> CreateNote([FromBody] NoteRequest request)
        {
            var userId = HttpContext.User.ExtractUserId();
            var parameter = _mapper.Map<NoteParameter>(request);

            var note = await _noteService.CreateNoteAsync(userId, parameter);

            return _mapper.Map<NoteResponse>(note);
        }

        [HttpPut("{noteId}")]
        public async Task<NoteResponse> UpdateNote(Guid noteId, [FromBody] NoteRequest request)
        {
            var userId = HttpContext.User.ExtractUserId();
            var parameter = _mapper.Map<NoteParameter>(request);

            var note = await _noteService.UpdateNoteAsync(userId, noteId, parameter);

            return _mapper.Map<NoteResponse>(note);
        }

        [HttpDelete("{noteId}")]
        public async Task<NoteResponse> DeleteNote(Guid noteId)
        {
            var userId = HttpContext.User.ExtractUserId();

            var note = await _noteService.DeleteNoteAsync(userId, noteId);

            return _mapper.Map<NoteResponse>(note);
        }
    }

}
