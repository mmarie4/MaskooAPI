using AutoMapper;
using MaskooAPI.Models.Diaries;
using MaskooAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Diaries;
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
    }
}
