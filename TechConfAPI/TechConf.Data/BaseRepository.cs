using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechConf.Data
{
    public class BaseRepository : IBaseRepository
    {
        private readonly TechConfDbContext dbContext;

        public BaseRepository(TechConfDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void SaveChangesAsync()
        {
            this.dbContext.SaveChangesAsync();
        }
    }
}
