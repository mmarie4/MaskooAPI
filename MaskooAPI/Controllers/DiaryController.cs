using AutoMapper;
using MaskooAPI.Models.Diaries;
using MaskooAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Diaries;
using Services.Diaries.Models;
using System;
using System.Threading.Tasks;

namespace MaskooAPI.Controllers
{

    [Route("api/diary")]
    [ApiController]
    [Authorize]
    public class DiaryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDiaryService _diaryService;

        public DiaryController(IMapper mapper, IDiaryService diaryService)
        {
            _mapper = mapper;
            _diaryService = diaryService;
        }

        [HttpGet]
        public async Task<DiaryResponse> GetDiary([FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            var userId = HttpContext.User.ExtractUserId();
            
            var diary = await _diaryService.GetDiaryAsync(userId, from, to);

            return _mapper.Map<DiaryResponse>(diary);
        }

        [HttpPatch("{diaryId}/days")]
        public async Task<DiaryResponse> PatchDay([FromRoute] Guid diaryId, [FromBody] DayUpdateRequest request)
        {
            var userId = HttpContext.User.ExtractUserId();

            var diary = await _diaryService.PatchDayContentAsync(userId, diaryId, request.Date, _mapper.Map<DayUpdateParameter>(request));

            return _mapper.Map<DiaryResponse>(diary);
        }

    }
}
