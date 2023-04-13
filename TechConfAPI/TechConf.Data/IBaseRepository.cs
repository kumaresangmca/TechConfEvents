using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechConf.Data
{
    public interface IBaseRepository
    {
        public void SaveChangesAsync();
    }
}
