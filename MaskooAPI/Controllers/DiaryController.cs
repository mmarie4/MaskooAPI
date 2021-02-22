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
        public async Task<DiaryResponse> GetDiary()
        {
            var userId = HttpContext.User.ExtractUserId();
            
            var diary = await _diaryService.GetDiaryAsync(userId, null, null);

            return _mapper.Map<DiaryResponse>(diary);
        }

        [HttpPost("{diaryId}/days")]
        public async Task<DiaryResponse> AddDay([FromRoute] Guid diaryId, [FromBody] DayCreationRequest request)
        {
            var userId = HttpContext.User.ExtractUserId();

            var diary = await _diaryService.AddDayAsync(userId, diaryId, request.Date);

            return _mapper.Map<DiaryResponse>(diary);
        }

        [HttpPut("{diaryId}/days/{dayId}")]
        public async Task<DiaryResponse> UpdateDay([FromRoute] Guid diaryId, [FromRoute] Guid dayId, [FromBody] DayUpdateRequest request)
        {
            var userId = HttpContext.User.ExtractUserId();

            var diary = await _diaryService.UpdateDayAsync(userId, diaryId, dayId, _mapper.Map<DayUpdateParameter>(request));

            return _mapper.Map<DiaryResponse>(diary);
        }

        [HttpDelete("{diaryId}/days/{dayId}")]
        public async Task<DiaryResponse> RemoveDay([FromRoute] Guid diaryId, [FromRoute] Guid dayId)
        {
            var userId = HttpContext.User.ExtractUserId();

            var diary = await _diaryService.RemoveDayAsync(diaryId, dayId);

            return _mapper.Map<DiaryResponse>(diary);
        }
    }
}
