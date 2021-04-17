using AutoMapper;
using DAL.Entities.Tools;
using MaskooAPI.Models.Toolboxes;
using Services.Tools.Models;

namespace MaskooAPI.Mappers
{
    public class ToolMapper : Profile
    {
        public ToolMapper()
        {
            CreateMap<Tool, ToolResponse>();

            CreateMap<Toolbox, ToolboxResponse>();

            CreateMap<ToolboxRequest, ToolboxParameter>();

            CreateMap<ToolRequest, ToolParameter>();

        }
    }
}
