using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechConf.Models.DTO;
using TechConf.Models.Models;

namespace TechConf.Mappers.Contracts
{
    public interface IMapper<ServiceModel, DTOModel> where ServiceModel : class where DTOModel : class
    {
        public ServiceModel MapDTOModelToServiceModel(DTOModel modelDTO);
        public DTOModel ModelServiceModelToDTOModel(ServiceModel model);
    }
}
