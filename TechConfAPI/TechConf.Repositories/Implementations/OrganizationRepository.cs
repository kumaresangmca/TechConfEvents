﻿using Microsoft.EntityFrameworkCore;
using TechConf.Data;
using TechConf.Models.Models;
using TechConf.Repositories.Contracts;

namespace TechConf.Repositories.Implementations
{
    public class OrganizationRepository : BaseRepository, IOrganizationRepository<Organization>
    {
        private readonly TechConfDbContext dbContext;
        public OrganizationRepository(TechConfDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        // Get All Organization
        public async Task<List<Organization>> GetAllAsync(int pageNo, int pageSize)
        {
            return await dbContext.Organizations.Skip((pageNo-1)  * pageSize).Take(pageSize).ToListAsync();
        }

        // Get Organization By Id
        public async Task<Organization?> GetByIdAsync(int id)
        {
            return await dbContext.Organizations.FirstOrDefaultAsync(s => s.Id == id);
        }

        // Get Organization By Code
        public async Task<Organization?> GetByCodeAsync(string code)
        {
            Organization? organization = await dbContext.Organizations.FirstOrDefaultAsync(s => s.Code == code);
            if (organization == null)
            {
                return null;
            }
            return organization;
        }
        // Get Organization By API Key
        public async Task<Organization?> GetByApiKeyAsync(string apiKey)
        {
            Organization? organization = await dbContext.Organizations.FirstOrDefaultAsync(s => s.ApiKey == apiKey);
            if (organization == null)
            {
                return null;
            }
            return organization;
        }
        // Add Organization
        public async Task<Organization> AddAsync(Organization model)
        {
            await dbContext.Organizations.AddAsync(model);
            return model;
        }

        // Update Existing Organization
        public async Task<bool> EditAsync(int id, Organization model)
        {
            Organization? existingOrganization = await dbContext.Organizations.FirstOrDefaultAsync(s => s.Id == id);
            if (existingOrganization == null)
            {
                return false;
            }
            else
            {
                dbContext.Entry(existingOrganization).State = EntityState.Detached;
            }
            dbContext.Attach(model);
            dbContext.Entry(model).State = EntityState.Modified;
            return true;
        }

        // Delete Organization
        public void DeleteAsync(Organization model)
        {
            dbContext.Organizations.Remove(model);
        }

    }
}
