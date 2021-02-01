using System;
using AutoMapper;

namespace MaskooAPI.Controllers
{
    public class DiaryController
    {
        private readonly IMapper _mapper;

        public DiaryController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
