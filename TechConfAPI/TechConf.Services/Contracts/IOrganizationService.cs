﻿using TechConf.Models.DTO;
using TechConf.Models.Models;

namespace TechConf.Services.Contracts
{
    public interface IOrganizationService<DTOModel> : IService<DTOModel> where DTOModel: class
    {
        public Task<DTOModel?> GetByCodeAsync(string code);
        public Task<DTOModel?> GetByApiKeyAsync(string apiKey);
    }
}
