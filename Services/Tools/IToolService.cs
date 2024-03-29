﻿using DAL.Entities.Tools;
using Services.Tools.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Tools
{
    public interface IToolService
    {
        Task<ICollection<Toolbox>> GetAllUserToolboxes(Guid userId, string searchTerm);

        Task<Toolbox> GetToolboxAsync(Guid toolboxId);

        Task<Toolbox> CreateToolboxAsync(Guid userId, ToolboxParameter parameter);

        Task<Toolbox> UpdateToolboxAsync(Guid userId, Guid toolboxId, ToolboxParameter parameter);

        Task<Toolbox> DeleteToolBoxAsync(Guid userId, Guid toolboxId);

        Task<Toolbox> AddToolAsync(Guid userId, Guid toolboxId, ToolParameter toolPrameter);

        Task<Toolbox> UpdateToolAsync(Guid userId, Guid toolboxId, Guid toolId, ToolParameter toolParameter);

        Task<Toolbox> RemoveToolAsync(Guid userId, Guid toolboxId, Guid toolId);
    }
}
