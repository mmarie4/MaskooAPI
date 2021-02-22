using AutoMapper;
using DAL.Entities.Diaries;
using MaskooAPI.Models.Diaries;
using Services.Diaries.Models;

namespace MaskooAPI.Mappers
{
    public class DiaryMapper : Profile
    {
        public DiaryMapper()
        {
            CreateMap<Diary, DiaryResponse>();

            CreateMap<Day, DayResponse>();

            CreateMap<DayUpdateRequest, DayUpdateParameter>();

        }
    }
}
