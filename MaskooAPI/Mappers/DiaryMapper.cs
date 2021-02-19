using AutoMapper;
using DAL.Entities.Diaries;
using MaskooAPI.Models.Diaries;

namespace MaskooAPI.Mappers
{
    public class DiaryMapper : Profile
    {
        public DiaryMapper()
        {
            CreateMap<Diary, DiaryResponse>();

            CreateMap<Day, DayResponse>();
        }
    }
}
