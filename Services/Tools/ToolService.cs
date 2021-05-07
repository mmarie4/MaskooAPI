using DAL.Entities;
using DAL.Entities.Tools;
using DAL.Repositories.Tools;
using Services.Tools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Tools
{
    public class ToolService : IToolService
    {

        private readonly IToolboxRepository _toolboxRepository;

        public ToolService(IToolboxRepository toolboxRepository)
        {
            _toolboxRepository = toolboxRepository;
        }

        public async Task<ICollection<Toolbox>> GetAllUserToolboxes(Guid userId, string searchTerm)
        {
            return await _toolboxRepository.GetAllByUserId(userId, searchTerm);
        }

        public async Task<Toolbox> GetToolboxAsync(Guid toolboxId)
        {
            return await _toolboxRepository.GetByIdAsync(toolboxId);
        }

        public async Task<Toolbox> CreateToolboxAsync(Guid userId, ToolboxParameter parameter)
        {
            var toolbox = new Toolbox()
            {
                Label = parameter.Name
            };
            toolbox.Stamp(userId);

            var result = await _toolboxRepository.AddAsync(toolbox);
            await _toolboxRepository.SaveAsync();

            return result;
        }

        public async Task<Toolbox> UpdateToolboxAsync(Guid userId, Guid toolboxId, ToolboxParameter parameter)
        {
            var toolbox = await _toolboxRepository.GetByIdAsync(toolboxId);

            toolbox.Label = parameter.Name;
            toolbox.Stamp(userId, false);

            var result = await _toolboxRepository.Update(toolbox);
            await _toolboxRepository.SaveAsync();

            return result;
        }

        public async Task<Toolbox> DeleteToolBoxAsync(Guid userId, Guid toolboxId)
        {
            var toolbox = await _toolboxRepository.GetByIdAsync(toolboxId);

            var result = await _toolboxRepository.Remove(toolbox);
            await _toolboxRepository.SaveAsync();

            return result;
        }

        public async Task<Toolbox> AddToolAsync(Guid userId, Guid toolboxId, ToolParameter toolParameter)
        {
            var toolbox = await _toolboxRepository.GetByIdAsync(toolboxId);

            var tool = new Tool()
            {
                Label = toolParameter.Label,
                Value = toolParameter.Value
            };
            tool.Stamp(userId);

            toolbox.Stamp(userId, false);

            var result = await _toolboxRepository.Update(toolbox);
            await _toolboxRepository.SaveAsync();

            return result;
        }

        public async Task<Toolbox> UpdateToolAsync(Guid userId, Guid toolboxId, Guid toolId, ToolParameter toolParameter)
        {
            var toolbox = await _toolboxRepository.GetByIdAsync(toolboxId);

            var tool = toolbox.Tools.FirstOrDefault(x => x.Id == toolId);
            tool.Label = toolParameter.Label;
            tool.Value = toolParameter.Value;

            tool.Stamp(userId, false);

            toolbox.Stamp(userId, false);

            var result = await _toolboxRepository.Update(toolbox);
            await _toolboxRepository.SaveAsync();

            return result;
        }

        public async Task<Toolbox> RemoveToolAsync(Guid userId, Guid toolboxId, Guid toolId)
        {
            var toolbox = await _toolboxRepository.GetByIdAsync(toolboxId);

            var tool = toolbox.Tools.FirstOrDefault(x => x.Id == toolId);
            toolbox.Tools.Remove(tool);

            toolbox.Stamp(userId, false);

            var result = await _toolboxRepository.Update(toolbox);
            await _toolboxRepository.SaveAsync();

            return result;
        }
    }
}
