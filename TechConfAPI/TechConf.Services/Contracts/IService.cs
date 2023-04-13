using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechConf.Models.DTO;

namespace TechConf.Services.Contracts
{
    public interface IService<DTOModel> where DTOModel: class
    {
        public Task<List<DTOModel>> GetAllAsync(int pageNo, int pageSize);
        public Task<DTOModel?> GetByIdAsync(int id);
        public Task<DTOModel> AddAsync(DTOModel model);
        public Task<bool> EditAsync(int id, DTOModel model);
        public Task<bool> DeleteAsync(int id);
        public void SaveChangesAsync();
    }
}
