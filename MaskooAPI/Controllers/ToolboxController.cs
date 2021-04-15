using AutoMapper;
using MaskooAPI.Models.Toolboxes;
using MaskooAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Tools;
using Services.Tools.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaskooAPI.Controllers
{
    [Route("api/toolbox")]
    [ApiController]
    [Authorize]
    public class ToolboxController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IToolService _toolService;

        public ToolboxController(IMapper mapper, IToolService ToolService)
        {
            _mapper = mapper;
            _toolService = ToolService;
        }

        [HttpGet]
        public async Task<ICollection<ToolboxResponse>> GetAllUserToolboxes()
        {
            var userId = HttpContext.User.ExtractUserId();

            var Toolbox = await _toolService.GetAllUserToolboxes(userId);

            return _mapper.Map<ICollection<ToolboxResponse>>(Toolbox);
        }

        [HttpPost]
        public async Task<ToolboxResponse> AddToolbox([FromBody] ToolboxCreationRequest request)
        {
            var userId = HttpContext.User.ExtractUserId();

            var parameter = _mapper.Map<ToolboxParameter>(request);

            var toolbox = await _toolService.CreateToolboxAsync(userId, parameter);

            return _mapper.Map<ToolboxResponse>(toolbox);
        }

        [HttpGet("{toolboxId}")]
        public async Task<ToolboxResponse> GetToolbox(Guid toolboxId)
        {
            var userId = HttpContext.User.ExtractUserId();

            var toolbox = await _toolService.GetToolboxAsync(toolboxId);

            return _mapper.Map<ToolboxResponse>(toolbox);
        }

        [HttpDelete("{toolboxId}")]
        public async Task<ToolboxResponse> DeleteToolbox(Guid toolboxId)
        {
            var userId = HttpContext.User.ExtractUserId();

            var toolbox = await _toolService.DeleteToolBoxAsync(userId, toolboxId);

            return _mapper.Map<ToolboxResponse>(toolbox);
        }

        [HttpPost("{toolboxId}/tools")]
        public async Task<ToolboxResponse> AddTool([FromRoute] Guid toolboxId, [FromBody] ToolRequest request)
        {
            var userId = HttpContext.User.ExtractUserId();

            var parameter = _mapper.Map<ToolParameter>(request);

            var toolbox = await _toolService.AddToolAsync(userId, toolboxId, parameter);

            return _mapper.Map<ToolboxResponse>(toolbox);
        }

        [HttpPut("{toolboxId}/tools/{toolId}")]
        public async Task<ToolboxResponse> UpdateTool([FromRoute] Guid toolboxId, [FromRoute] Guid toolId, [FromBody] ToolRequest request)
        {
            var userId = HttpContext.User.ExtractUserId();

            var parameter = _mapper.Map<ToolParameter>(request);

            var toolbox = await _toolService.UpdateToolAsync(userId, toolboxId, toolId, parameter);

            return _mapper.Map<ToolboxResponse>(toolbox);
        }

        [HttpDelete("{toolboxId}/tools/{toolId}")]
        public async Task<ToolboxResponse> RemoveTool([FromRoute] Guid toolboxId, [FromRoute] Guid toolId)
        {
            var userId = HttpContext.User.ExtractUserId();

            var Toolbox = await _toolService.RemoveToolAsync(userId, toolboxId, toolId);

            return _mapper.Map<ToolboxResponse>(Toolbox);
        }
    }
}
