using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechConf.Models.DTO
{
    public class ResultDTO<T>
    {
        public T? Results { get; set; }
        public List<string> ErrorsMessages { get; set; }
        public ResultDTO()
        {
            ErrorsMessages = new List<string>();
        }


    }
}
